using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using AForge.Video;
using AForge.Video.DirectShow;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        Bitmap image;
        private bool recording;
        List<Bitmap> imageList;
        private string buttontext = "";
        private int currentContrast = 0;
        private int currentBrightness = 0;

        private void CreateMp4FromBitmaps(List<Bitmap> frames, string outputFilePath, double fps = 10.0)
        {
            if (frames == null || frames.Count == 0)
            {
                MessageBox.Show("No frames to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int width = frames[0].Width;
            int height = frames[0].Height;
            var outDir = Path.GetDirectoryName(outputFilePath);
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);
            try
            {
                int fourcc = VideoWriter.FourCC('M', 'P', '4', 'V');
                using (var writer = new VideoWriter())
                {
                    bool opened = writer.Open(outputFilePath, fourcc, fps, new OpenCvSharp.Size(width, height));
                    if (!opened)
                    {
                        MessageBox.Show("Failed to open VideoWriter. Try a different fourcc (e.g. MJPG) or check codecs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (var bmp in frames)
                    {
                        if (bmp == null) continue;
                        using (var mat = BitmapConverter.ToMat(bmp))
                        {
                            if (mat.Width != width || mat.Height != height)
                            {
                                using (var resized = mat.Resize(new OpenCvSharp.Size(width, height)))
                                {
                                    writer.Write(resized);
                                }
                            }
                            else
                            {
                                writer.Write(mat);
                            }
                        }
                    }
                    writer.Release();
                }
                MessageBox.Show("Zapisano Wideo!", "Koniec", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad przy zapisie wideo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ApplyBrightnessContrast(Bitmap source, int brightness, int contrast)
        {
            using (var srcMat = BitmapConverter.ToMat(source))
            using (var dstMat = new Mat())
            {
                double alpha = (contrast + 100) / 100.0; // contrast: -100..100 -> alpha 0..2
                double beta = brightness;               // brightness: -100..100 -> beta -100..100
                srcMat.ConvertTo(dstMat, MatType.CV_8UC3, alpha, beta);
                return BitmapConverter.ToBitmap(dstMat);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }
            if (cboDevice.Items.Count > 0)
                cboDevice.SelectedIndex = 0;
            imageList = new List<Bitmap>();
            if (trackBar1 != null) currentContrast = trackBar1.Value;
            if (trackBar2 != null) currentBrightness = trackBar2.Value;
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frameBmp = null;
            Bitmap adjusted = null;
            try
            {
                frameBmp = (Bitmap)eventArgs.Frame.Clone();
                adjusted = ApplyBrightnessContrast(frameBmp, currentBrightness, currentContrast);
                if (pictureBox.Image != null) pictureBox.Image.Dispose();
                pictureBox.Image = (Bitmap)adjusted.Clone();
                image = (Bitmap)adjusted.Clone();
                
                if (recording)
                {
                    var clone = (Bitmap)adjusted.Clone();
                    lock (imageList)
                    {
                        imageList.Add(clone);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (adjusted != null) adjusted.Dispose();
                if (frameBmp != null) frameBmp.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.SignalToStop();
                captureDevice.WaitForStop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }

        private void scrnBtn_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                image.Dispose();
            }
            image = (Bitmap)pictureBox.Image;
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Brak obrazu do zapisu!");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images (*.png)|*.png;*.bmp;*.jpg";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat format = ImageFormat.Png;
                string ext = Path.GetExtension(saveFileDialog.FileName).ToLower();
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                image.Save(saveFileDialog.FileName, format);
                MessageBox.Show("Zapisano obraz!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Button btn = sender as Button;
            if (btn != null)
            {
                if (buttontext == "")
                {
                    buttontext = btn.Text;
            }
                if (recording)
                {
                    btn.Text = buttontext;
                } else
                {
                    btn.Text = "STOP";
                }
            }
            if (recording)
            {
                recording = false;
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Videos|*.mp4";
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<Bitmap> framesToSave;
                        lock (imageList)
                        {
                            framesToSave = imageList.Select(b => (Bitmap)b.Clone()).ToList();
                        }
                        CreateMp4FromBitmaps(framesToSave, saveFileDialog.FileName);
                        foreach (var bmp in framesToSave) bmp.Dispose();
                        lock (imageList)
                        {
                            foreach (var bmp in imageList) bmp.Dispose();
                            imageList.Clear();
                        }
                    }
                }
                return;
            }
            recording = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentContrast = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            currentBrightness = trackBar2.Value;
        }
    }
}

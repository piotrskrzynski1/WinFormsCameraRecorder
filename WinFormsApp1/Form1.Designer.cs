namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            cboDevice = new ComboBox();
            pictureBox = new PictureBox();
            btnStart = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            scrnBtn = new Button();
            button1 = new Button();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            label4 = new Label();
            trackBar3 = new TrackBar();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 31);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Cameras:";
            // 
            // cboDevice
            // 
            cboDevice.FormattingEnabled = true;
            cboDevice.Location = new Point(241, 27);
            cboDevice.Margin = new Padding(3, 4, 3, 4);
            cboDevice.Name = "cboDevice";
            cboDevice.Size = new Size(379, 28);
            cboDevice.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Location = new Point(14, 89);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(606, 493);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(645, 194);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 31);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // scrnBtn
            // 
            scrnBtn.Location = new Point(645, 249);
            scrnBtn.Margin = new Padding(3, 4, 3, 4);
            scrnBtn.Name = "scrnBtn";
            scrnBtn.Size = new Size(93, 31);
            scrnBtn.TabIndex = 5;
            scrnBtn.Text = "Zrób Zdjęcie";
            scrnBtn.UseVisualStyleBackColor = true;
            scrnBtn.Click += scrnBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(645, 306);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 6;
            button1.Text = "Nagraj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(645, 449);
            trackBar1.Margin = new Padding(3, 4, 3, 4);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = -100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(214, 56);
            trackBar1.TabIndex = 7;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(645, 355);
            trackBar2.Margin = new Padding(3, 4, 3, 4);
            trackBar2.Maximum = 100;
            trackBar2.Minimum = -100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(214, 56);
            trackBar2.TabIndex = 8;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(725, 395);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 9;
            label2.Text = "Jasność";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(720, 489);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 10;
            label3.Text = "Kontrast";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(645, 48);
            progressBar1.Maximum = 50;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(214, 29);
            progressBar1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(725, 25);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 12;
            label4.Text = "Ruch";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(636, 89);
            trackBar3.Maximum = 255;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(223, 56);
            trackBar3.TabIndex = 13;
            trackBar3.Value = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(716, 79);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 15;
            label5.Text = "Tolerance";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label5);
            Controls.Add(trackBar3);
            Controls.Add(label4);
            Controls.Add(progressBar1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(button1);
            Controls.Add(scrnBtn);
            Controls.Add(btnStart);
            Controls.Add(pictureBox);
            Controls.Add(cboDevice);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Camera App";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboDevice;
        private PictureBox pictureBox;
        private Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private Button scrnBtn;
        private Button button1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Label label2;
        private Label label3;
        private ProgressBar progressBar1;
        private Label label4;
        private TrackBar trackBar3;
        private Label label5;
    }
}

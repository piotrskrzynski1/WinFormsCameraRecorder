# WinForms Camera Recorder

A simple C# Windows Forms application for capturing webcam video and screenshots with adjustable brightness and contrast. Videos can be saved as MP4 files and images as PNG, JPG, or BMP.

## Features

- Capture video from any connected webcam/camera
- Take screenshots and save them to disk
- Adjustable **brightness** and **contrast** using trackbars
- Record video frames and save as MP4
- Lightweight and easy to use

## Screenshot

<img width="796" height="486" alt="image" src="https://github.com/user-attachments/assets/a2e5c7d5-1fa8-43ba-ae13-a889d3a32bb6" />

## Requirements

- Windows 10/11
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022
- NuGet packages:
  - AForge.Video
  - AForge.Video.DirectShow
  - OpenCvSharp4
  - OpenCvSharp4.Extensions
  - OpenCvSharp4.runtime.win

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/piotrskrzynski1/WinFormsCameraRecorder.git
3. Open the solution WinFormsApp1.sln in Visual Studio.
4. Restore NuGet packages.
5. Build and run the project.

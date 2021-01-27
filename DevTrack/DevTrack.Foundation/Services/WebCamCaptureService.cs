using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        VideoCapture capture;
        Mat frame;
        Bitmap image;

        public Image WebCamCapture()
        {
            capture = new VideoCapture(0);
            capture.Open(0);

            frame = new Mat();
            capture.Read(frame);
            Thread.Sleep(2000);
            image = BitmapConverter.ToBitmap(frame);
            Bitmap snapshot = new Bitmap(image);


            //---Save Image for Testing purpose ----------///
            //string path = @"C:\camTest\";
            //string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");
            //snapshot.Save(string.Format(path + FileName + ".jpg"));


            capture.Release();

            return image;
        }

        
    }
}

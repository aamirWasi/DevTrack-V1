using System;
using System.Drawing;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        private VideoCapture _capture;
        private Mat _frame;
        private Bitmap _image;

        public string WebCamCapture()
        {
            _capture = new VideoCapture(0);
            _capture.Open(0);
            _frame = new Mat();
            _capture.Read(_frame);

            Thread.Sleep(2000);
            
            _image = BitmapConverter.ToBitmap(_frame);
            Bitmap snapshot = new Bitmap(_image);

            //---Save Image ----------///
            string path = @"C:\camTest\";
            string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");
            snapshot.Save(string.Format(path + FileName + ".jpg"));


            _capture.Release();

            return path;

        }

        
    }
}

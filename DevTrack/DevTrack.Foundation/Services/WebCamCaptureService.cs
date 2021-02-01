using System;
using System.Drawing;
using System.IO;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        private VideoCapture _capture;
        private Mat _frame;
        private string _FullImagePath;
        private Bitmap _image;

        public string WebCamCapture()
        {
            _capture = new VideoCapture(0);
            _capture.Open(0);
            _frame = new Mat();
            _capture.Read(_frame);

            Thread.Sleep(2000);
            
            _image = BitmapConverter.ToBitmap(_frame);


            //---Save Image ----------///

            string Folder = string.Format(Directory.GetCurrentDirectory() + @"\WebCamCapture");

            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");

            _FullImagePath = string.Format(Folder + "\\" + FileName + ".jpg");

            _image.Save(string.Format(_FullImagePath));

            _capture.Release();

            return _FullImagePath;
        }

        
    }
}

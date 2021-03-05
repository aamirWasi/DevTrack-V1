using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace DevTrack.Foundation.Adapters
{
    public class WebCamImageAdapter : IWebCamImageAdapter
    {
        private VideoCapture _capture;
        private Mat _frame;
        private Bitmap _image;
        private string _path;

        public (Image image, String path) WebCamCapture()
        {
            _capture = new VideoCapture();
            _capture.Open(0);
            _frame = new Mat();
            _capture.Read(_frame);

            Thread.Sleep(2000);

            _image = BitmapConverter.ToBitmap(_frame);
            _path = CreatePath();
            _image.Save(_path);

            _capture.Release();

            return (_image, _path);
        }

        private string CreatePath()
        {
            string Folder = string.Format(Directory.GetCurrentDirectory() + @"\WebCamCapture");

            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            var FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");
            var FullImagePath = string.Format(Folder + "\\" + FileName + ".jpg");

            return FullImagePath;
        }

    }
}

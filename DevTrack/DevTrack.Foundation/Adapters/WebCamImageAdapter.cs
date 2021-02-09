using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace DevTrack.Foundation.Adapters
{
    public class WebCamImageAdapter : IWebCamImageAdapter
    {
        private VideoCapture _capture;
        private Mat _frame;
        private Bitmap _image;

        public Image WebCamCapture()
        {
            _capture = new VideoCapture();
            _capture.Open(0);
            _frame = new Mat();
            _capture.Read(_frame);

            Thread.Sleep(2000);

            _image = BitmapConverter.ToBitmap(_frame);

            _capture.Release();

            return _image;
        }
    }
}

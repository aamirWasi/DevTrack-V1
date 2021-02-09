using System;
using System.Drawing;
using System.IO;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        private VideoCapture _capture;
        private Mat _frame;
        private string _FullImagePath;
        private Bitmap _image;

        private readonly IWebCamCaptureUnitOfWork _WebCamCaptureUnitOfWork;

        public WebCamCaptureService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork)
        {
            _WebCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
        }

        public void WebCamCaptureImageSave()
        {
            var img = WebCamCapture();
            var path = CreatePath();

            if(img != null) img.Save(path);

            var WebImageEntity = new WebCamCaptureImage
            {
                WebCamImagePath = path,
                WebCamImageDateTime = DateTime.Now
            };

            _WebCamCaptureUnitOfWork._webCamCaptureRepository.Add(WebImageEntity);
            _WebCamCaptureUnitOfWork.Save();
        }

        

        private string CreatePath()
        {
            string Folder = string.Format(Directory.GetCurrentDirectory() + @"\WebCamCapture");

            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            string FileName = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss-tt");

            _FullImagePath = string.Format(Folder + "\\" + FileName + ".jpg");

            return _FullImagePath;
        }
        
    }
}

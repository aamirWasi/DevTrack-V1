using System;
using System.Drawing;
using System.IO;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Adapters;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        private readonly IWebCamCaptureUnitOfWork _WebCamCaptureUnitOfWork;
        private readonly IWebCamImageAdapter _webCamImageAdapter;

        public WebCamCaptureService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork, IWebCamImageAdapter webCamImageAdapter)
        {
            _WebCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
            _webCamImageAdapter = webCamImageAdapter;
        }

        public void WebCamCaptureImageSave()
        {
            var WebCamAdapterObject = _webCamImageAdapter.WebCamCapture();

            var img = WebCamAdapterObject.image;

            if(img == null)
                throw new InvalidOperationException("Image information is missing");

            var WebImageEntity = new WebCamCaptureImage
            {
                WebCamImagePath = WebCamAdapterObject.path,
                WebCamImageDateTime = DateTimeOffset.Now
            };

            _WebCamCaptureUnitOfWork._webCamCaptureRepository.Add(WebImageEntity);
            _WebCamCaptureUnitOfWork.Save();
        }
 
    }
}

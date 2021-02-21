using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureWebService
    {
        private readonly IWebCamCaptureUnitOfWork _webCamCaptureUnitOfWork;

        public WebCamCaptureWebService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork)
        {
            _webCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
        }

        public void SaveSnapShotWebDb(WebCamCaptureImage image)
        {
            if (image == null)
            {
                throw new InvalidOperationException("Image information is  missing");
            }
            else
            {
                _webCamCaptureUnitOfWork._webCamCaptureRepository.Add(image);
                _webCamCaptureUnitOfWork.Save();
            }
        }
    }
}
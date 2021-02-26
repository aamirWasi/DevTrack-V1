using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureWebService : IWebCamCaptureWebService
    {
        private readonly IWebCamCaptureWebUnitOfWork _webCamCaptureWebUnitOfWork;

        public WebCamCaptureWebService(IWebCamCaptureWebUnitOfWork webCamCaptureWebUnitOfWork)
        {
            _webCamCaptureWebUnitOfWork = webCamCaptureWebUnitOfWork;
        }

        public void SaveSnapShotWebDb(WebCamCaptureImage image)
        {
            if (image == null)
            {
                throw new InvalidOperationException("Image information is  missing");
            }
            else
            {
                _webCamCaptureWebUnitOfWork._webCamCaptureWebRepository.Add(image);
                _webCamCaptureWebUnitOfWork.Save();
            }
        }
    }
}
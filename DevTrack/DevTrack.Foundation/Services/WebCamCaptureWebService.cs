using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureWebService : IWebCamCaptureWebService
    {
        private readonly IWebCamCaptureWebUnitOfWork _webCamCaptureWebUnitOfWork;
        private readonly IWebCamCaptureAdapterService _webCamCaptureAdapterService;

        public WebCamCaptureWebService(IWebCamCaptureWebUnitOfWork webCamCaptureWebUnitOfWork,IWebCamCaptureAdapterService webCamCaptureAdapterService)
        {
            _webCamCaptureWebUnitOfWork = webCamCaptureWebUnitOfWork;
            _webCamCaptureAdapterService = webCamCaptureAdapterService;
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

        public string SaveSnapshotInSql(WebCamCaptureImage imageEntity)
        {
            if (imageEntity != null)
                return _webCamCaptureAdapterService.WebHttpResponse(imageEntity);
            else
                throw new InvalidOperationException("Image information is invalid");
        }
    }
}
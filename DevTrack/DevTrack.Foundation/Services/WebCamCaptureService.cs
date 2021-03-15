using System;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Adapters;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureService : IWebCamCaptureService
    {
        private readonly IWebCamCaptureUnitOfWork _WebCamCaptureUnitOfWork;
        private readonly IWebCamImageAdapter _webCamImageAdapter;
        private readonly IWebCamCaptureApiService _webCamCaptureApiService;
        private readonly IWebCamCaptureLocalService _webCamCaptureLocalService;
        private readonly IFileManager _helper;

        public WebCamCaptureService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork, 
                                    IWebCamImageAdapter webCamImageAdapter, 
                                    IWebCamCaptureApiService webCamCaptureApiService,
                                    IWebCamCaptureLocalService webCamCaptureLocalService,
                                    IFileManager helper)
        {
            _WebCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
            _webCamImageAdapter = webCamImageAdapter;
            _webCamCaptureApiService = webCamCaptureApiService;
            _webCamCaptureLocalService = webCamCaptureLocalService;
            _helper = helper;
        }

        public void WebCamCaptureImageSave()
        {
            var webCamAdapterObject = _webCamImageAdapter.WebCamCapture();

            var img = webCamAdapterObject.image;

            if(img == null)
                throw new InvalidOperationException("Image information is missing");

            var WebImageEntity = new WebCamCaptureImage
            {
                WebCamImagePath = webCamAdapterObject.path,
                WebCamImageDateTime = DateTimeOffset.Now
            };

            _WebCamCaptureUnitOfWork.WebCamCaptureRepository.Add(WebImageEntity);
            _WebCamCaptureUnitOfWork.Save();
        }

        public void SyncWebCamImages()
        {
            var images = _WebCamCaptureUnitOfWork.WebCamCaptureRepository.GetAll();
            if (images.Count > 0)
            {
                foreach (var image in images)
                {
                    var imageEntity = new WebCamCaptureImage
                    {
                        WebCamImageDateTime = image.WebCamImageDateTime,
                        WebCamImagePath = image.WebCamImagePath
                    };

                    var result = _webCamCaptureApiService.SaveCapturedImageInSql(imageEntity);
                    _webCamCaptureLocalService.RemoveImageFromSqLite(result, image.Id);
                    _webCamCaptureLocalService.RemoveImageFromFolder(imageEntity.WebCamImagePath);
                }
            }
        }

    }
}

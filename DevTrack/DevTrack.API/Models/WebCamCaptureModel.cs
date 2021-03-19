using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace DevTrack.API.Models
{
    public class WebCamCaptureModel : WebCamImageSaveModel
    {
        public IFormFile FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private const string IMAGE_PATH = @"images\WebCamCapture";
        private IWebCamCaptureWebService _webCamCaptureWebService;
        private readonly IS3FileUploaderService _s3FileUploaderService;

        public WebCamCaptureModel() : base(IMAGE_PATH)
        {
            _webCamCaptureWebService = Startup.AutofacContainer.Resolve<IWebCamCaptureWebService>();
            _s3FileUploaderService = Startup.AutofacContainer.Resolve<IS3FileUploaderService>();
        }

        public WebCamCaptureModel(string IMAGE_PATH) : base(IMAGE_PATH)
        {
        }

        public void SaveWebCamCapture()
        {
            if (FilePath != null)
            {
                var (fileName, filePath) = StoreFile(FilePath);

                _webCamCaptureWebService.SaveSnapShotWebDb(new WebCamCaptureImage
                {
                    WebCamImagePath = fileName,
                    WebCamImageDateTime = CaptureTime
                });

                _s3FileUploaderService.UploadFile(fileName, filePath);
            }
        }
    }
}

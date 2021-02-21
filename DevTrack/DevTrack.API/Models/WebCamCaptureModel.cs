using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace DevTrack.API.Models
{
    public class WebCamCaptureModel : BaseModel
    {
        public IFormFile FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private IWebCamCaptureWebService _webCamCaptureWebService;

        public WebCamCaptureModel()
        {
            _webCamCaptureWebService = Startup.AutofacContainer.Resolve<IWebCamCaptureWebService>();
        }

        public void SaveWebCamCapture()
        {
            if (FilePath != null)
            {
                var (fileName, filePath) = StoreFile(FilePath);

                _webCamCaptureWebService.SaveSnapShotWebDb(new WebCamCaptureImage
                {
                    WebCamImagePath = filePath,
                    WebCamImageDateTime = CaptureTime
                });

            }
        }
    }
}

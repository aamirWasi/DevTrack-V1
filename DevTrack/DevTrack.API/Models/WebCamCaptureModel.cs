using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace DevTrack.API.Models
{
    public class WebCamCaptureModel
    {
        public IFormFile FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private ISnapShotWebService _snapShotWebService;

        public WebCamCaptureModel()
        {
            _snapShotWebService = Startup.AutofacContainer.Resolve<ISnapShotWebService>();
        }

        public void SaveWebCamCapture()
        {
            if (FilePath != null)
            {
                var (fileName, filePath) = StoreFile(FilePath);

                _snapShotWebService.SaveSnapShotWebDb(new SnapshotImage
                {
                    FilePath = filePath,
                    CaptureTime = CaptureTime
                });
            }
        }
    }
}

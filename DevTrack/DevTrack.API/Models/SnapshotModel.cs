using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.API.Models
{
    public class SnapshotModel : SnapshotSaveModel
    {
        public IFormFile FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private const string IMAGE_PATH = @"images/snapshots";
        private readonly ISnapShotWebService _snapShotWebService;
        private readonly IS3FileUploaderService _s3FileUploaderService;

        public SnapshotModel() : base(IMAGE_PATH)
        {
            _snapShotWebService = Startup.AutofacContainer.Resolve<ISnapShotWebService>();
            _s3FileUploaderService = Startup.AutofacContainer.Resolve<IS3FileUploaderService>();
        }

        public SnapshotModel(string IMAGE_PATH) : base(IMAGE_PATH)
        {
        }

        public void SaveSnapshot()
        {
            if (FilePath != null)
            {
                var (fileName, filePath) = StoreFile(FilePath);

                _snapShotWebService.SaveSnapShotWebDb(new SnapshotImage
                {
                    FilePath = fileName,
                    CaptureTime = CaptureTime
                });

                _s3FileUploaderService.UploadFile(fileName, filePath);
            }
        }
    }
}

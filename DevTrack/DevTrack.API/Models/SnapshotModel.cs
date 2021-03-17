using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.API.Models
{
    public class SnapshotModel : BaseModel
    {
        public IFormFile FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private ISnapShotWebService _snapShotWebService;
        private readonly IS3FileUploaderService _s3FileUploaderService;

        public SnapshotModel()
        {
            _snapShotWebService = Startup.AutofacContainer.Resolve<ISnapShotWebService>();
            _s3FileUploaderService = Startup.AutofacContainer.Resolve<IS3FileUploaderService>();
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

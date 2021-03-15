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

        public SnapshotModel()
        {
            _snapShotWebService = Startup.AutofacContainer.Resolve<ISnapShotWebService>();
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
            }
        }
    }
}

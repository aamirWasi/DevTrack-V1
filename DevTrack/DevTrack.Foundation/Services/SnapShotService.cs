using DevTrack.Foundation.UnitOfWorks;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapShotService : ISnapShotService
    {
        public string FilePath { get; set; }
        public DateTimeOffset CaptureTime { get; set; }

        private ISnapshotUnitOfWork _snapshotUnitOfWork;
        private IBitMapAdapter _image;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork,IBitMapAdapter image)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _image = image;
        }
     
        public void SnapshotCapturer()
        {
            var snapshot = _image.GenerateSnapshot2();
            var image = snapshot.image;
            if (image == null)
                throw new InvalidOperationException("Image information is missing");

            var imageEntity = new EO.SnapshotImage
            {
                CaptureTime = DateTimeOffset.Now,
                FilePath = snapshot.fileLoaction
            };

            _snapshotUnitOfWork.SnapshotRepository.Add(imageEntity);
            _snapshotUnitOfWork.Save();
        }
    }
}
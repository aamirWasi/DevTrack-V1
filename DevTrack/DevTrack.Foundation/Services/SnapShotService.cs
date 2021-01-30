using DevTrack.Foundation.UnitOfWorks;
using BO = DevTrack.Foundation.BusinessObjects;
using EO = DevTrack.Foundation.Entities;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapShotService : ISnapShotService
    {
        private readonly ISnapshotUnitOfWork _snapshotUnitOfWork;

        public SnapShotService(ISnapshotUnitOfWork snapshotUnitOfWork)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
        }

        public void SnapshotCapturer(BO.SnapshotImage image)
        {
            if (image == null)
                throw new InvalidOperationException("Image information is missing");

            var imageEntity = new EO.SnapshotImage
            {
                FilePath = image.FilePath
            };

            _snapshotUnitOfWork.SnapshotRepository.Add(imageEntity);
            _snapshotUnitOfWork.Save();
        }
    }
}
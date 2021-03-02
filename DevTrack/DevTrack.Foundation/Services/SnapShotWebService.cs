using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public class SnapShotWebService : ISnapShotWebService
    {
        private readonly ISnapshotWebUnitOfWork _snapshotWebUnitOfWork;

        public SnapShotWebService(ISnapshotWebUnitOfWork snapshotWebUnitOfWork)
        {
            _snapshotWebUnitOfWork = snapshotWebUnitOfWork;
        }

        public void SaveSnapShotWebDb(SnapshotImage image)
        {
            if (image == null)
            {
                throw new InvalidOperationException("Image information is  missing");
            }
            else
            {
                _snapshotWebUnitOfWork.SnapshotWebRepository.Add(image);
                _snapshotWebUnitOfWork.Save();
            }
        }
    }
}
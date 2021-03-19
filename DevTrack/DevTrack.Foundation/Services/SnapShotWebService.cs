using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Adapters;

namespace DevTrack.Foundation.Services
{
    public class SnapShotWebService : ISnapShotWebService
    {
        private readonly ISnapshotWebUnitOfWork _snapshotWebUnitOfWork;
        private readonly ISnapShotWebAdapterService _snapShotWebAdapterService;

        public SnapShotWebService(ISnapshotWebUnitOfWork snapshotWebUnitOfWork, ISnapShotWebAdapterService snapShotWebAdapterService)
        {
            _snapshotWebUnitOfWork = snapshotWebUnitOfWork;
            _snapShotWebAdapterService = snapShotWebAdapterService;
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

        public string SaveSnapshotInSql(SnapshotImage imageEntity)
        {
            if (imageEntity != null)
                return _snapShotWebAdapterService.WebHttpResponse(imageEntity);
            else
                throw new InvalidOperationException("Image information is invalid");
        }
    }
}
using DevTrack.Foundation.UnitOfWorks;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapshotLocalService : ISnapshotLocalService
    {
        private readonly ISnapshotUnitOfWork _snapshotUnitOfWork;
        private readonly IHelper _helper;

        public SnapshotLocalService(ISnapshotUnitOfWork snapshotUnitOfWork, IHelper helper)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _helper = helper;
        }

        public void RemoveImageFromSqLite(string returnResult, int id)
        {
            if (returnResult == "true")
            {
                var imageRemove = _snapshotUnitOfWork.SnapshotRepository.GetById(id);
                _snapshotUnitOfWork.SnapshotRepository.Remove(imageRemove);
                _snapshotUnitOfWork.Save();
            }
        }

        public void RemoveImageFromFolder(string path)
        {
            _helper.RemoveFileFromDirectory(path);
        }
    }
}
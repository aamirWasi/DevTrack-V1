using DevTrack.Foundation.UnitOfWorks;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapshotLocalService : ISnapshotLocalService
    {
        private ISnapshotUnitOfWork _snapshotUnitOfWork;

        public SnapshotLocalService(ISnapshotUnitOfWork snapshotUnitOfWork)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
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
            File.Delete(path);
        }
    }
}
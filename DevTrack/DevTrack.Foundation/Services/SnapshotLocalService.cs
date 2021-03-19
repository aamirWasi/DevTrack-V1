using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System.IO;
using System;

namespace DevTrack.Foundation.Services
{
    public class SnapshotLocalService : ISnapshotLocalService
    {
        private readonly ISnapshotUnitOfWork _snapshotUnitOfWork;
        private readonly IFileManager _fileManager;

        public SnapshotLocalService(ISnapshotUnitOfWork snapshotUnitOfWork, IFileManager fileManager)
        {
            _snapshotUnitOfWork = snapshotUnitOfWork;
            _fileManager = fileManager;
        }

        public void RemoveImageFromSqLite(string returnResult, int id)
        {
            if (returnResult == "true")
            {
                var imageRemove = _snapshotUnitOfWork.SnapshotRepository.GetById(id);
                _snapshotUnitOfWork.SnapshotRepository.Remove(imageRemove);
                _snapshotUnitOfWork.Save();
            }

            else
            {
                throw new InvalidProgramException("Result is false");
            }
        }

        public void RemoveImageFromFolder(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                _fileManager.RemoveFileFromDirectory(path);
            }
            else
            {
                throw new InvalidOperationException("File path must be provided to remove from local directory");
            }
        }
    }
}
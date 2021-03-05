﻿using DevTrack.Foundation.UnitOfWorks;
using System.IO;

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
        }

        public void RemoveImageFromFolder(string path)
        {
            _fileManager.RemoveFileFromDirectory(path);
        }
    }
}
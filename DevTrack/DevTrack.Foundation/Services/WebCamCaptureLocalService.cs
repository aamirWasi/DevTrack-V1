using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureLocalService : IWebCamCaptureLocalService
    {
        private IWebCamCaptureUnitOfWork _webCamCaptureUnitOfWork;
        private readonly IFileManager _fileManager;

        public WebCamCaptureLocalService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork, IFileManager fileManager)
        {
            _webCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
            _fileManager = fileManager;
        }

        public void RemoveImageFromSqLite(string returnResult, int id)
        {
            if (returnResult == "true")
            {
                var imageRemove = _webCamCaptureUnitOfWork.WebCamCaptureRepository.GetById(id);
                _webCamCaptureUnitOfWork.WebCamCaptureRepository.Remove(imageRemove);
                _webCamCaptureUnitOfWork.Save();
            }
            else
            {
                throw new InvalidProgramException("Response is false");
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
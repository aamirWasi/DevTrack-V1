using DevTrack.Foundation.UnitOfWorks;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class WebCamCaptureLocalService : IWebCamCaptureLocalService
    {
        private IWebCamCaptureUnitOfWork _webCamCaptureUnitOfWork;

        public WebCamCaptureLocalService(IWebCamCaptureUnitOfWork webCamCaptureUnitOfWork)
        {
            _webCamCaptureUnitOfWork = webCamCaptureUnitOfWork;
        }

        public void RemoveImageFromSqLite(string returnResult, int id)
        {
            if (returnResult == "true")
            {
                var imageRemove = _webCamCaptureUnitOfWork._webCamCaptureRepository.GetById(id);
                _webCamCaptureUnitOfWork._webCamCaptureRepository.Remove(imageRemove);
                _webCamCaptureUnitOfWork.Save();
            }
        }

        public void RemoveImageFromFolder(string path)
        {
            File.Delete(path);
        }
    }
}
using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class WebCamCaptureWebUnitOfWork : UnitOfWork, IWebCamCaptureWebUnitOfWork
    {
        public WebCamCaptureWebUnitOfWork(DevTrackWebContext devTrackWebContext, IWebCamCaptureWebRepository webCamCaptureWebRepository) : base(devTrackWebContext)
        {
            _webCamCaptureWebRepository = webCamCaptureWebRepository;
        }

        public IWebCamCaptureWebRepository _webCamCaptureWebRepository { get; set; }
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IWebCamCaptureWebUnitOfWork : IUnitOfWork
    {
        IWebCamCaptureWebRepository _webCamCaptureWebRepository { get; set; }
    }
}

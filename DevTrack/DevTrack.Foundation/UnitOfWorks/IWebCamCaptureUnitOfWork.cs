using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IWebCamCaptureUnitOfWork : IUnitOfWork
    {
        public IWebCamCaptureRepository webCamCaptureRepository { get; set; }
    }
}

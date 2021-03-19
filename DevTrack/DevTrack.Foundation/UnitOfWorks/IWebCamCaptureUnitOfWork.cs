using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IWebCamCaptureUnitOfWork : IUnitOfWork
    {
        public IWebCamCaptureRepository WebCamCaptureRepository { get; set; }
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IMouseTrackUnitOfWork : IUnitOfWork
    {
        public IMouseTrackRepository MouseTrackRepository { get; set; }
    }
}
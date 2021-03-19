using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IMouseTrackUnitOfWork : IUnitOfWork
    {
        public IMouseTrackRepository MouseTrackRepository { get; set; }
    }
}
using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks.Interfaces
{
    public interface IKeyboardTrackUnitOfWork : IUnitOfWork
    {
        public IKeyboardTrackRepository KeyboardTrackRepository { get; set; }
    }
}
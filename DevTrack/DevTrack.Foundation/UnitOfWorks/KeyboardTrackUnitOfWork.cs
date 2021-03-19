using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class KeyboardTrackUnitOfWork : UnitOfWork, IKeyboardTrackUnitOfWork
    {

        public KeyboardTrackUnitOfWork(
            DevTrackContext devTrackContext,
            IKeyboardTrackRepository keyboardTrackRepository)
            : base(devTrackContext)
        {
            KeyboardTrackRepository = keyboardTrackRepository;
        }

        public IKeyboardTrackRepository KeyboardTrackRepository { get; set; }
    }
}

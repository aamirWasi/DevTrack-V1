using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class KeyboardWebUnitOfWork : UnitOfWork, IKeyboardWebUnitOfWork
    {
        public KeyboardWebUnitOfWork(DevTrackWebContext devTrackWeb,
            IKeyboardWebRepository keyboardWebRepository) : base(devTrackWeb)
        {
            KeyboardWebRepository = keyboardWebRepository;
        }

        public IKeyboardWebRepository KeyboardWebRepository { get; set; }
    }
}
using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

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
using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IKeyboardTrackUnitOfWork : IUnitOfWork
    {
    }

    public class KeyboardTrackUnitOfWork : UnitOfWork, IKeyboardTrackUnitOfWork
    {
        private readonly IKeyboardTrackRepository _keyboardTrackRepository;

        public KeyboardTrackUnitOfWork(
            DevTrackContext devTrackContext,
            IKeyboardTrackRepository keyboardTrackRepository)
            : base(devTrackContext)
        {
            _keyboardTrackRepository = keyboardTrackRepository;
        }
    }
}

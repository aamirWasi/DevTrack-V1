using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private readonly IKeyboardTrackAdapter _keyboardTrackAdapter;
        public KeyboardTrackService(
            IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork,
            IKeyboardTrackAdapter keyboardTrackAdapter)
        {
            _keyboardTrackUnitOfWork = keyboardTrackUnitOfWork;
            _keyboardTrackAdapter = keyboardTrackAdapter;
        }
        
        public void KeyboardTrackSave()
        {
            var keyboardEntity = _keyboardTrackAdapter.KeyboardEntity();
            if (keyboardEntity == null) return;
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }
    }
}

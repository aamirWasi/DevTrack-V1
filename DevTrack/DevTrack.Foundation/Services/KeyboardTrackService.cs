using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private readonly IKeyboardTrackAdapter _keyboardTrackAdapter;
        private bool _firstTime = true;
        public KeyboardTrackService(
            IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork,
            IKeyboardTrackAdapter keyboardTrackAdapter)
        {
            _keyboardTrackUnitOfWork = keyboardTrackUnitOfWork;
            _keyboardTrackAdapter = keyboardTrackAdapter;
        }
        
        public void KeyboardTrackSave()
        {
            if (_firstTime)
            {
                _firstTime = false;
                return;
            }

            var keyboardEntity = _keyboardTrackAdapter.KeyboardEntity();
            _keyboardTrackUnitOfWork.KeyboardTrackRepository.Add(keyboardEntity);
            _keyboardTrackUnitOfWork.Save();
        }
    }
}

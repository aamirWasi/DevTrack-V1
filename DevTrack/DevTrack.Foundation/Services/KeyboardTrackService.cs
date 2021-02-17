using System.Collections.Generic;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class KeyboardTrackService : IKeyboardTrackService
    {
        private readonly IKeyboardTrackUnitOfWork _keyboardTrackUnitOfWork;
        private readonly IKeyboardTrackStartService _keyboardTrackAdapter;
        public KeyboardTrackService(
            IKeyboardTrackUnitOfWork keyboardTrackUnitOfWork,
            IKeyboardTrackStartService keyboardTrackAdapter)
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

        public IList<Keyboard> GetKeyboard()
        {
            return _keyboardTrackUnitOfWork.KeyboardTrackRepository.GetAll();
        }
    }
}

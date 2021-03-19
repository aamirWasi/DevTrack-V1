using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class KeyboardWebService : IKeyboardWebService
    {
        private readonly IKeyboardWebUnitOfWork _keyboardWeb;

        public KeyboardWebService(IKeyboardWebUnitOfWork keyboardWeb)
        {
            _keyboardWeb = keyboardWeb;
        }
        public void SaveKeyboardIntoWeb(Keyboard keyboard)
        {
            if (keyboard == null) return;
            _keyboardWeb.KeyboardWebRepository.Add(keyboard);
            _keyboardWeb.Save();
        }
    }
}
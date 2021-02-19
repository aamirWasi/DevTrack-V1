using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;

namespace DevTrack.API.Models
{
    public class KeyboardModel
    {
        private readonly IKeyboardWebService _keyboardWeb;

        public KeyboardModel()
        {
            _keyboardWeb = Startup.AutofacContainer.Resolve<IKeyboardWebService>();
        }

        public void SaveKeyboardIntoWeb(Keyboard keyboard)
        {
            _keyboardWeb.SaveKeyboardIntoWeb(keyboard);
        }
    }
}

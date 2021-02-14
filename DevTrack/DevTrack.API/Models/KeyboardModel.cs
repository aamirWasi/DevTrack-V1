using Autofac;
using DevTrack.Foundation.Services;

namespace DevTrack.API.Models
{
    public class KeyboardModel
    {
        private readonly IKeyboardTrackService _keyboardTrackService;

        public KeyboardModel(IKeyboardTrackService keyboardTrackService)
        {
            _keyboardTrackService = keyboardTrackService;
        }

        public KeyboardModel()
        {
            _keyboardTrackService = Startup.AutofacContainer.Resolve<IKeyboardTrackService>();
        }


    }
}

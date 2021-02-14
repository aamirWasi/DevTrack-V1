using System.Collections;
using System.Collections.Generic;
using Autofac;
using DevTrack.Foundation.Entities;
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

        public IList<Keyboard> TrackedData()
        {
            return _keyboardTrackService.GetKeyboard();
        }

    }
}

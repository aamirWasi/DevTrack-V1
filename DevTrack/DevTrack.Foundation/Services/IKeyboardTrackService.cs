using System.Collections.Generic;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IKeyboardTrackService
    {
         void KeyboardTrackSave();
         IList<Keyboard> GetKeyboard();
    }
}
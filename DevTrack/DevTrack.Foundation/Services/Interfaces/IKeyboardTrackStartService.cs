using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IKeyboardTrackStartService
    {
        void KeyboardTrack();
        Keyboard KeyboardEntity();
    }
}
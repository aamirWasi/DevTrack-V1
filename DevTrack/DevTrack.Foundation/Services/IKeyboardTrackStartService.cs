using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IKeyboardTrackStartService
    {
        void KeyboardTrack();
        Keyboard KeyboardEntity();
    }
}
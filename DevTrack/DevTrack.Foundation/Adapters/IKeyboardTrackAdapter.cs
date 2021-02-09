using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Adapters
{
    public interface IKeyboardTrackAdapter
    {
        void KeyboardTrack();
        Keyboard KeyboardEntity();
        bool IsFirst { get; set; }
    }
}
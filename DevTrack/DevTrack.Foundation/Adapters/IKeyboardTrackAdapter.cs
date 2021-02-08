using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Adapters
{
    public interface IKeyboardTrackAdapter
    {
        void KeyboardTrack();
        internal Keyboard KeyboardEntity();
    }
}
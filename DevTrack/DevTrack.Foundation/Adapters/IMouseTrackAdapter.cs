using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Adapters
{
    public interface IMouseTrackAdapter
    {
        void MouseTrack();
        internal Mouse MouseEntity();
    }
}
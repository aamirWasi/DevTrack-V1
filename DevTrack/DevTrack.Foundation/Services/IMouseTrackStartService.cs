using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface IMouseTrackStartService
    {
        void MouseTrack();
        Mouse MouseEntity();
    }
}
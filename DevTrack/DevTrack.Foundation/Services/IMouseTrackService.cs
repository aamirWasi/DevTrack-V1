namespace DevTrack.Foundation.Services
{
    public interface IMouseTrackService
    {
        void MouseTrackSaveToLocal();
        void SyncMouseDataFromLocal();
    }
}
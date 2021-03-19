namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IMouseTrackService
    {
        void MouseTrackSaveToLocal();
        void SyncMouseDataFromLocal();
    }
}
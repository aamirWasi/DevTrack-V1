namespace DevTrack.Foundation.Services
{
    public interface IKeyboardTrackService
    {
         void KeyboardTrackSaveToLocal();
         void SyncKeyboardDataFromLocal();
    }
}
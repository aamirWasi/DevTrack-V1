namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IKeyboardTrackService
    {
         void KeyboardTrackSaveToLocal();
         void SyncKeyboardDataFromLocal();
    }
}
using DevTrack.Foundation.BusinessObjects;

namespace DevTrack.Foundation.Services
{
    public interface ISnapShotService
    {
        void SnapshotCapturer(SnapshotImage image);
    }
}
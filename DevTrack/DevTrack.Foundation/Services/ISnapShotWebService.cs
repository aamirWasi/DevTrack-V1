using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface ISnapShotWebService
    {
        void SaveSnapShotWebDb(SnapshotImage image);
    }
}
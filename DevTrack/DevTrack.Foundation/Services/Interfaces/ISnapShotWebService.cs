using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface ISnapShotWebService
    {
        void SaveSnapShotWebDb(SnapshotImage image);
        string SaveSnapshotInSql(SnapshotImage imageEntity);
    }
}
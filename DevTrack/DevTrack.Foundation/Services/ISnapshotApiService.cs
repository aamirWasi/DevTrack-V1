using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Services
{
    public interface ISnapshotApiService
    {
        string SaveSnapshotInSql(SnapshotImage imageEntity);
    }
}
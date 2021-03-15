using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Adapters
{
    public interface ISnapShotWebAdapterService
    {
        string WebHttpResponse(SnapshotImage imageEntity);
    }
}
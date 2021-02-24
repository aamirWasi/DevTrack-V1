namespace DevTrack.Foundation.Services
{
    public interface ISnapshotLocalService
    {
        void RemoveImageFromSqLite(string final, int id);
        void RemoveImageFromFolder(string path);
    }
}
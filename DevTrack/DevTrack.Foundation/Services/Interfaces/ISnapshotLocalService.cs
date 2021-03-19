namespace DevTrack.Foundation.Services.Interfaces
{
    public interface ISnapshotLocalService
    {
        void RemoveImageFromSqLite(string final, int id);
        void RemoveImageFromFolder(string path);
    }
}
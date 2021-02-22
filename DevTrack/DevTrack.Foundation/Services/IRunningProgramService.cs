namespace DevTrack.Foundation.Services
{
    public interface IRunningProgramService
    {
        void AddRunningProgramsLocalDb();
        void SyncRunningPrograms();
    }
}

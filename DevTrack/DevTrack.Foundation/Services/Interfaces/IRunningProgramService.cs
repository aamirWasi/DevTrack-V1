namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IRunningProgramService
    {
        void AddRunningProgramsLocalDb();
        void SyncRunningPrograms();
    }
}

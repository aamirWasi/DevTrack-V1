using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IProjectUnitOfWork : IUnitOfWork
    {
        IProjectRepository projectRepository { get; set; }
        ISettingsRepository settingsRepository { get; set; }
    }
}
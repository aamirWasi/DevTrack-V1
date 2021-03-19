using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IProjectUnitOfWork : IUnitOfWork
    {
        IProjectRepository projectRepository { get; set; }
        ISettingsRepository settingsRepository { get; set; }
    }
}
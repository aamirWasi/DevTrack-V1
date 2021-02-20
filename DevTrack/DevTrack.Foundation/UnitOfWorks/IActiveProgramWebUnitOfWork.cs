using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public interface IActiveProgramWebUnitOfWork : IUnitOfWork
    {
        IActiveProgramWebRepository ActiveProgramWebRepository { get; set; }
    }
}

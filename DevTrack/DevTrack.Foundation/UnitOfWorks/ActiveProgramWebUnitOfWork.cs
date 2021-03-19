using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class ActiveProgramWebUnitOfWork : UnitOfWork, IActiveProgramWebUnitOfWork
    {
        public ActiveProgramWebUnitOfWork(DevTrackWebContext activeProgramWebContext, IActiveProgramWebRepository activeProgramWebRepository) : base(activeProgramWebContext)
        {
            ActiveProgramWebRepository = activeProgramWebRepository;
        }

        public IActiveProgramWebRepository ActiveProgramWebRepository { get; set; }
    }
}

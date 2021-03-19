using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class ActiveProgramWebRepository : Repository<ActiveProgram, int, DevTrackWebContext>, IActiveProgramWebRepository
    {
        public ActiveProgramWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}

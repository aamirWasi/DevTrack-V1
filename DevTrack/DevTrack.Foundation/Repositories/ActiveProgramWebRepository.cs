using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class ActiveProgramWebRepository : Repository<ActiveProgram, int, DevTrackWebContext>, IActiveProgramWebRepository
    {
        public ActiveProgramWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}

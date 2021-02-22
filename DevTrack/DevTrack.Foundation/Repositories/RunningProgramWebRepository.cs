using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class RunningProgramWebRepository : Repository<RunningProgram, int, DevTrackWebContext>, IRunningProgramWebRepository
    {
        public RunningProgramWebRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}

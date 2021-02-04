using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public class RunningProgramRepository : Repository<RunningProgram, int, DevTrackContext>, IRunningProgramRepository
    {
        public RunningProgramRepository(DevTrackContext devTrackContext) : base(devTrackContext)
        {

        }
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Repositories
{
    public class ActiveProgramRepository : Repository<ActiveProgram, int, DevTrackContext>, IActiveProgramRepository
    {
        public ActiveProgramRepository(DevTrackContext devTrackContext) : base(devTrackContext)
        {

        }
    }
}

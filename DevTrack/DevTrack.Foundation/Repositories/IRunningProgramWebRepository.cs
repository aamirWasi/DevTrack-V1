using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Repositories
{
    public interface IRunningProgramWebRepository : IRepository<RunningProgram, int, DevTrackWebContext>
    {
    }
}

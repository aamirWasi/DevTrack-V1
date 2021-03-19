using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Repositories.Interfaces
{
    public interface IActiveProgramRepository : IRepository<ActiveProgram, int, DevTrackContext>
    {
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using System;
using System.Collections.Generic;
using DevTrack.Foundation.Repositories.Interfaces;
using System.Text;

namespace DevTrack.Foundation.Repositories
{
    public class ProjectRepository : Repository<Project, int, DevTrackWebContext>, IProjectRepository
    {
        public ProjectRepository(DevTrackWebContext devTrackWebContext) : base(devTrackWebContext)
        {

        }
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class ProjectUnitOfWork : UnitOfWork, IProjectUnitOfWork
    {
        public IProjectRepository projectRepository { get; set; }

        public ProjectUnitOfWork(ProjectContext projectContext, IProjectRepository _projectRepository) : base(projectContext)
        {
            projectRepository = _projectRepository;
        }
    }
}

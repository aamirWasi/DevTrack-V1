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
        public ISettingsRepository settingsRepository { get; set; }

        public ProjectUnitOfWork(DevTrackProjectContext projectContext, IProjectRepository _projectRepository, ISettingsRepository _settingsRepository) : base(projectContext)
        {
            projectRepository = _projectRepository;
            settingsRepository = _settingsRepository;
        }
    }
}

using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class ProjectUnitOfWork : UnitOfWork, IProjectUnitOfWork
    {
        public IProjectRepository projectRepository { get; set; }
        public ISettingsRepository settingsRepository { get; set; }

        public ProjectUnitOfWork(DevTrackWebContext devTrackWebContext, IProjectRepository _projectRepository, ISettingsRepository _settingsRepository) : base(devTrackWebContext)
        {
            projectRepository = _projectRepository;
            settingsRepository = _settingsRepository;
        }
    }
}

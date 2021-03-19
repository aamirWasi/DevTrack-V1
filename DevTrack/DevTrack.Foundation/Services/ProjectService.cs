using System;
using System.Collections.Generic;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;
using System.Linq;

namespace DevTrack.Foundation.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectUnitOfWork _projectUnitOfWork;

        public ProjectService()
        {}

        public ProjectService(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }

        public void CreateProject(BO.Project project)
        {
            var projectEntity = new EO.Project
            {
                Name = project.Name,
                CreateDate = project.CreationTime,
                IsAdmin = project.IsAdmin,
                UserId = project.UserId,
                AspNetUsersId = project.UserId
            };

            projectEntity.Settings = new EO.Settings
            {
                AllowTracking = project.Settings.AllowTracking,
                TrackActiveProgram = project.Settings.TrackActiveProgram,
                TakeScreenShot = project.Settings.TakeScreenShot,
                TrackKeyboardHits = project.Settings.TrackKeyboardHits,
                TrackMouseHits = project.Settings.TrackMouseHits,
                TrackRunningProgram = project.Settings.TrackRunningProgram,
                WebCamCapture = project.Settings.WebCamCapture
            };

            _projectUnitOfWork.projectRepository.Add(projectEntity);
            _projectUnitOfWork.Save();
        }

        public void EditProject(BO.Project project)
        {
            var projectEntity = _projectUnitOfWork.projectRepository.Get(x => x.Id == project.Id, "Settings").FirstOrDefault();

            projectEntity.Name = project.Name;
            projectEntity.IsAdmin = project.IsAdmin;

            projectEntity.Settings.AllowTracking = project.Settings.AllowTracking;
            projectEntity.Settings.TakeScreenShot = project.Settings.TakeScreenShot;
            projectEntity.Settings.WebCamCapture = project.Settings.WebCamCapture;
            projectEntity.Settings.TrackActiveProgram = project.Settings.TrackActiveProgram;
            projectEntity.Settings.TrackRunningProgram = project.Settings.TrackRunningProgram;
            projectEntity.Settings.TrackKeyboardHits = project.Settings.TrackKeyboardHits;
            projectEntity.Settings.TrackMouseHits = project.Settings.TrackMouseHits;

            _projectUnitOfWork.Save();
        }

        public void DeleteProject(int id)
        {
            var project = _projectUnitOfWork.projectRepository.Get(x => x.Id == id, "Settings").FirstOrDefault();
            _projectUnitOfWork.projectRepository.Remove(project);
            _projectUnitOfWork.settingsRepository.Remove(project.Settings.Id);
            _projectUnitOfWork.Save();
        }

        public IList<BO.Project> GetProjectList(Guid userId)
        {
            var ProjectList = _projectUnitOfWork.projectRepository.Get(x => x.UserId == userId, "Settings");
            return BO.Project.ConvertToProjectList(ProjectList);
        }

        public BO.Project GetProject(int id)
        {
            var projectEntity = _projectUnitOfWork.projectRepository.Get(x => x.Id == id, orderBy: null, "Settings", true).FirstOrDefault();

            return BO.Project.ConvertToSelf(projectEntity);
        }
    }
}

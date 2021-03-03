using System;
using System.Collections.Generic;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectUnitOfWork _projectUnitOfWork;

        public ProjectService()
        { }

        public ProjectService(ProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }

        public void CreateProject(BO.Project project)
        {
            var projectEntity = new EO.Project
            {
                Name = project.Name,
                CreateDate = project.CreationTime,
                IsAdmin = project.IsAdmin
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
            //_projectUnitOfWork.Save();
        }

        public void EditProject(BO.Project project)
        {

        }

        public void DeleteProject(int id)
        {

        }

        public void GetAllProject()
        {

        }
    }
}

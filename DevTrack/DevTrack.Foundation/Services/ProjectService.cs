using System;
using System.Collections.Generic;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.UnitOfWorks;
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
            _projectUnitOfWork.Save();
        }

        public void EditProject(BO.Project project)
        {
            var projectEntity = _projectUnitOfWork.projectRepository.Get(x => x.Id == project.Id, orderBy: null, "Settings", true).FirstOrDefault();

            projectEntity.Name = project.Name;
            projectEntity.IsAdmin = project.IsAdmin;

            projectEntity.Settings = new EO.Settings
            {
                Id = project.Settings.Id,
                AllowTracking = project.Settings.AllowTracking,
                TrackActiveProgram = project.Settings.TrackActiveProgram,
                TakeScreenShot = project.Settings.TakeScreenShot,
                TrackKeyboardHits = project.Settings.TrackKeyboardHits,
                TrackMouseHits = project.Settings.TrackMouseHits,
                TrackRunningProgram = project.Settings.TrackRunningProgram,
                WebCamCapture = project.Settings.WebCamCapture
            };

            //projectEntity.Settings.AllowTracking = project.Settings.AllowTracking;
            //projectEntity.Settings.TakeScreenShot = project.Settings.TrackRunningProgram;
            //projectEntity.Settings.WebCamCapture = project.Settings.TrackRunningProgram;
            //projectEntity.Settings.TrackActiveProgram = project.Settings.TrackRunningProgram;
            //projectEntity.Settings.TrackRunningProgram = project.Settings.TrackRunningProgram;
            //projectEntity.Settings.TrackKeyboardHits = project.Settings.TrackKeyboardHits;
            //projectEntity.Settings.TrackMouseHits = project.Settings.TrackMouseHits;

            _projectUnitOfWork.Save();
        }

        public void DeleteProject(int id)
        {
            var project = _projectUnitOfWork.projectRepository.Get(x => x.Id == id, "Settings").FirstOrDefault();

            _projectUnitOfWork.projectRepository.Remove(project);
            _projectUnitOfWork.Save();
        }

        public IList<BO.Project> GetProjectList()
        {
            var ProjectList = _projectUnitOfWork.projectRepository.GetAll();
            return BO.Project.ConvertToProjectList(ProjectList);
        }

        public BO.Project GetProject(int id)
        {
            var projectEntity = _projectUnitOfWork.projectRepository.Get(x => x.Id == id, orderBy: null, "Settings", true).FirstOrDefault();

            return BO.Project.ConvertToSelf(projectEntity);
        }
    }
}

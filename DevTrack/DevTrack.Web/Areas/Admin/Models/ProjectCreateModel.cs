using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrack.Web.Areas.Admin.Models
{
    public class ProjectCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsAdmin { get; set; }
        public Settings Settings { get; set; }

        private readonly IProjectUnitOfWork _projectUnitOfWork;

        public ProjectCreateModel()
        { }

        public ProjectCreateModel(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }

        public void CreateProject()
        {
            var ProjectEntity = new Project
            {
                Name = Name,
                CreateDate = DateTime.Now,
                IsAdmin = true                
            };

            ProjectEntity.Settings = new Settings
            {
                AllowTracking = Settings.AllowTracking,
                TrackActiveProgram = Settings.TrackActiveProgram,
                TakeScreenShot = Settings.TakeScreenShot,
                TrackKeyboardHits = Settings.TrackKeyboardHits,
                TrackMouseHits = Settings.TrackMouseHits,
                TrackRunningProgram = Settings.TrackRunningProgram,
                WebCamCapture = Settings.WebCamCapture
            };

            ProjectEntity.User = new ApplicationUser
            {
                FullName = User.FullName,
                ImageUrl = User.ImageUrl
            };


            _projectUnitOfWork.projectRepository.Add(ProjectEntity);
            _projectUnitOfWork.Save();
        }
    }
}

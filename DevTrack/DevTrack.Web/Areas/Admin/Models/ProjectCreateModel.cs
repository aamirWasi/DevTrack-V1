using DevTrack.Foundation.BusinessObjects;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DevTrack.Foundation.Services;
using Autofac;

namespace DevTrack.Web.Areas.Admin.Models
{
    public class ProjectCreateModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public ApplicationUser User { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreationTime = DateTime.Now;
        public BO.Settings Settings { get; set; }

        private readonly IProjectService _projectService;

        public ProjectCreateModel()
        {
            _projectService = Startup.AutofacContainer.Resolve<IProjectService>();
        }

        public void CreateProject()
        {
            var project = ConvertToProjectBO();
            _projectService.CreateProject(project);
        }


        //public void CreateProject()
        //{
        //    var ProjectEntity = new EO.Project
        //    {
        //        Name = Name,
        //        CreateDate = DateTime.Now,
        //        IsAdmin = IsAdmin                
        //    };

        //    ProjectEntity.Settings = new EO.Settings
        //    {
        //        AllowTracking = Settings.AllowTracking,
        //        TrackActiveProgram = Settings.TrackActiveProgram,
        //        TakeScreenShot = Settings.TakeScreenShot,
        //        TrackKeyboardHits = Settings.TrackKeyboardHits,
        //        TrackMouseHits = Settings.TrackMouseHits,
        //        TrackRunningProgram = Settings.TrackRunningProgram,
        //        WebCamCapture = Settings.WebCamCapture
        //    };

        //    //ProjectEntity.User = new ApplicationUser
        //    //{
        //    //    FullName = User.FullName,
        //    //    ImageUrl = User.ImageUrl
        //    //};


        //    //_projectUnitOfWork.projectRepository.Add(ProjectEntity);
        //    //_projectUnitOfWork.Save();
        //}

        private BO.Project ConvertToProjectBO()
        {
            var ProductBO = new BO.Project
            {
                Name = Name,
                CreationTime = CreationTime,
                IsAdmin = IsAdmin
            };

            ProductBO.Settings = new Settings
            {
                AllowTracking = Settings.AllowTracking,
                TrackActiveProgram = Settings.TrackActiveProgram,
                TakeScreenShot = Settings.TakeScreenShot,
                TrackKeyboardHits = Settings.TrackKeyboardHits,
                TrackMouseHits = Settings.TrackMouseHits,
                TrackRunningProgram = Settings.TrackRunningProgram,
                WebCamCapture = Settings.WebCamCapture
            };

            return ProductBO;
        }

    }
}

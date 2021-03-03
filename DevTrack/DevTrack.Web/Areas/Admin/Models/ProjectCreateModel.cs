﻿using DevTrack.Foundation.BusinessObjects;
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
        public BO.Settings Setting { get; set; }
        public IList<BO.Project> ProjectList { get; set; }

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

        public void EditProject()
        {
            var project = ConvertToProjectBO();
            _projectService.EditProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
        }

        public void GetProjectList()
        {
            ProjectList = _projectService.GetProjectList();
        }

        public void GetProject(int id)
        {
            Id = id;
            var tempProject = _projectService.GetProject(id);

            if(tempProject != null)
            {
                Name = tempProject.Name;
                IsAdmin = tempProject.IsAdmin;
                CreationTime = tempProject.CreationTime;

                Setting = new BO.Settings();

                Setting.Id = tempProject.Settings.Id;
                Setting.AllowTracking = tempProject.Settings.AllowTracking;
                Setting.TrackActiveProgram = tempProject.Settings.TrackActiveProgram;
                Setting.TakeScreenShot = tempProject.Settings.TakeScreenShot;
                Setting.TrackKeyboardHits = tempProject.Settings.TrackKeyboardHits;
                Setting.TrackMouseHits = tempProject.Settings.TrackMouseHits;
                Setting.TrackRunningProgram = tempProject.Settings.TrackRunningProgram;
                Setting.WebCamCapture = tempProject.Settings.TrackRunningProgram;
            }

        }

        private BO.Project ConvertToProjectBO()
        {
            var ProductBO = new BO.Project
            {
                Id = Id,
                Name = Name,
                CreationTime = CreationTime,
                IsAdmin = IsAdmin
            };

            ProductBO.Settings = new Settings
            {
                Id = Setting.Id,
                AllowTracking = Setting.AllowTracking,
                TrackActiveProgram = Setting.TrackActiveProgram,
                TakeScreenShot = Setting.TakeScreenShot,
                TrackKeyboardHits = Setting.TrackKeyboardHits,
                TrackMouseHits = Setting.TrackMouseHits,
                TrackRunningProgram = Setting.TrackRunningProgram,
                WebCamCapture = Setting.WebCamCapture
            };

            return ProductBO;
        }

    }
}

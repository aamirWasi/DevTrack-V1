using System;
using System.Collections.Generic;
using System.Text;
using EO = DevTrack.Foundation.Entities;
using BO = DevTrack.Foundation.BusinessObjects;
using DevTrack.Membership.Entities;

namespace DevTrack.Foundation.BusinessObjects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreationTime { get; set; }
        public BO.Settings Settings { get; set; }
        static IList<BO.Project> ProjectList { get; set; }
        public Guid UserId { get; set; }

        public static Project ConvertToSelf(EO.Project project)
        {
            var projectBO = new Project
            {
                Name = project.Name,
                IsAdmin = project.IsAdmin,
                CreationTime = project.CreateDate
            };

            projectBO.Settings = new Settings
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

            return projectBO;
        }

        public static IList<Project> ConvertToProjectList(IList<EO.Project> projectList1)
        {
            ProjectList = new List<Project>();

            foreach (var project in projectList1)
            {
                var obj = new BO.Project
                {
                    Id = project.Id,
                    Name = project.Name
                };

                ProjectList.Add(obj);
            }

            return ProjectList;
        }
    }
}

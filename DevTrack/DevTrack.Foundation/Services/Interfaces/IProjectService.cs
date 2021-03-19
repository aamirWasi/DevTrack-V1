using DevTrack.Foundation.BusinessObjects;
using System;
using System.Collections.Generic;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IProjectService
    {
        void CreateProject(Project project);
        void DeleteProject(int id);
        void EditProject(Project project);
        IList<Project> GetProjectList(Guid userId);
        Project GetProject(int id);


    }
}
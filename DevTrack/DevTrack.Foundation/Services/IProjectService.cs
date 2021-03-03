using DevTrack.Foundation.BusinessObjects;
using System.Collections.Generic;

namespace DevTrack.Foundation.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project);
        void DeleteProject(int id);
        void EditProject(Project project);
        IList<Project> GetProjectList();
        Project GetProject(int id);


    }
}
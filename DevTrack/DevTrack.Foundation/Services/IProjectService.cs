using DevTrack.Foundation.BusinessObjects;

namespace DevTrack.Foundation.Services
{
    public interface IProjectService
    {
        void CreateProject(Project project);
        void DeleteProject(int id);
        void EditProject(Project project);
        void GetAllProject();
    }
}
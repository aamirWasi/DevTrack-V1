using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories
{
    public interface IProjectRepository : IRepository<Project, int, DevTrackProjectContext>
    {
    }
}
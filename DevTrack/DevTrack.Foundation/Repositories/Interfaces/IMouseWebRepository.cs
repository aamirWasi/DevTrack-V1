using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories.Interfaces
{
    public interface IMouseWebRepository : IRepository<Mouse, int, DevTrackWebContext>
    {
        
    }
}
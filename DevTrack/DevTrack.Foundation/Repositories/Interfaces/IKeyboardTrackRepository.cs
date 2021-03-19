using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.Repositories.Interfaces
{
    public interface IKeyboardTrackRepository : IRepository<Keyboard, int, DevTrackContext>
    {

    }
}
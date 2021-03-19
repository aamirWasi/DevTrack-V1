using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class KeyboardTrackRepository : Repository<Keyboard, int, DevTrackContext>, IKeyboardTrackRepository
    {
        public KeyboardTrackRepository(DevTrackContext devTrackContext) : base(devTrackContext)
        {

        }
    }
}

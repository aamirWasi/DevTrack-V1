using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class KeyboardWebRepository : Repository<Keyboard, int, DevTrackWebContext>, IKeyboardWebRepository
    {
        public KeyboardWebRepository(DevTrackWebContext context) : base(context)
        {
        }
    }
}
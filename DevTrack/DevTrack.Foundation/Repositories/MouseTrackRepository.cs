using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class MouseTrackRepository : Repository<Mouse, int, DevTrackContext>, IMouseTrackRepository
    {
        public MouseTrackRepository(DevTrackContext devTrackContext) : base(devTrackContext)
        {

        }
    }
}

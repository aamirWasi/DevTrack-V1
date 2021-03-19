using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Repositories.Interfaces;

namespace DevTrack.Foundation.Repositories
{
    public class MouseWebRepository: Repository<Mouse, int, DevTrackWebContext>, IMouseWebRepository
    {
        public MouseWebRepository(DevTrackWebContext context) : base(context)
        {
        }
    }
}
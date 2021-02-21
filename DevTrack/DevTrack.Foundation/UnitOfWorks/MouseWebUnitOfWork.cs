using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class MouseWebUnitOfWork : UnitOfWork, IMouseWebUnitOfWork
    {
        public MouseWebUnitOfWork(DevTrackWebContext devTrackWeb,
            IMouseWebRepository mouseWebRepository) : base(devTrackWeb)
        {
            MouseWebRepository = mouseWebRepository;
        }

        public IMouseWebRepository MouseWebRepository { get; set; }
    }
}
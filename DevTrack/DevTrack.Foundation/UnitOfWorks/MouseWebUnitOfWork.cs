using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

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
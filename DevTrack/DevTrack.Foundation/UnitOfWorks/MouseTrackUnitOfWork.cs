using DevTrack.DataAccessLayer;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.UnitOfWorks.Interfaces;

namespace DevTrack.Foundation.UnitOfWorks
{
    public class MouseTrackUnitOfWork : UnitOfWork, IMouseTrackUnitOfWork
    {

        public MouseTrackUnitOfWork(
            DevTrackContext devTrackContext,
            IMouseTrackRepository mouseTrackRepository
            ) : base(devTrackContext)
        {
            MouseTrackRepository = mouseTrackRepository;
        }

        public IMouseTrackRepository MouseTrackRepository { get; set; }
    }
}

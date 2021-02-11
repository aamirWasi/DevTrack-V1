using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class MouseTrackService : IMouseTrackService
    {
        private readonly IMouseTrackUnitOfWork _mouseTrackUnitOfWork;
        private readonly IMouseTrackStartService _mouseTrackAdapter;

        public MouseTrackService(
            IMouseTrackUnitOfWork mouseTrackUnitOfWork,
            IMouseTrackStartService mouseTrackAdapter)
        {
            _mouseTrackUnitOfWork = mouseTrackUnitOfWork;
            _mouseTrackAdapter = mouseTrackAdapter;
        }

        public void MouseTrackSave()
        {
            var mouseEntity = _mouseTrackAdapter.MouseEntity();
            if (mouseEntity == null) return;
            _mouseTrackUnitOfWork.MouseTrackRepository.Add(mouseEntity);
            _mouseTrackUnitOfWork.Save();
        }
    }
}

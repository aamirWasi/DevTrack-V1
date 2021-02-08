using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation.Services
{
    public class MouseTrackService : IMouseTrackService
    {
        private readonly IMouseTrackUnitOfWork _mouseTrackUnitOfWork;
        private readonly IMouseTrackAdapter _mouseTrackAdapter;
        private bool _firstTime = true;

        public MouseTrackService(
            IMouseTrackUnitOfWork mouseTrackUnitOfWork,
            IMouseTrackAdapter mouseTrackAdapter)
        {
            _mouseTrackUnitOfWork = mouseTrackUnitOfWork;
            _mouseTrackAdapter = mouseTrackAdapter;
        }

        public void MouseTrackSave()
        {
            if (_firstTime)
            {
                _firstTime = false;
                return;
            }

            var mouseEntity = _mouseTrackAdapter.MouseEntity();
            _mouseTrackUnitOfWork.MouseTrackRepository.Add(mouseEntity);
            _mouseTrackUnitOfWork.Save();
        }
    }
}

using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class MouseWebService : IMouseWebService
    {
        private readonly IMouseWebUnitOfWork _mouseWebUnitOfWork;

        public MouseWebService(IMouseWebUnitOfWork mouseWebUnitOfWork)
        {
            _mouseWebUnitOfWork = mouseWebUnitOfWork;
        }

        public void SaveMouseIntoWeb(Mouse mouse)
        {
            if (mouse == null) return;
            _mouseWebUnitOfWork.MouseWebRepository.Add(mouse);
            _mouseWebUnitOfWork.Save();
        }
    }
}
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.UnitOfWorks;

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
            _mouseWebUnitOfWork.MouseWebRepository.Add(mouse);
            _mouseWebUnitOfWork.Save();
        }
    }
}
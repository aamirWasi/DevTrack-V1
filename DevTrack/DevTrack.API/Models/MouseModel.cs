using Autofac;
using DevTrack.Foundation.Entities;
using DevTrack.Foundation.Services;

namespace DevTrack.API.Models
{
    public class MouseModel
    {
        private readonly IMouseWebService _mouseWebService;

        public MouseModel()
        {
            _mouseWebService = Startup.AutofacContainer.Resolve<IMouseWebService>();
        }

        public void SaveMouseIntoWeb(Mouse mouse)
        {
            _mouseWebService.SaveMouseIntoWeb(mouse);
        }
    }
}
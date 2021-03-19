using Autofac;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.API.Models
{
    public class MouseModel
    {
        private readonly IMouseWebService _mouseWebService;

        public MouseModel()
        {
            _mouseWebService = Startup.AutofacContainer.Resolve<IMouseWebService>();
        }

        public int TotalClicks { get; set; }
        public int LeftButtonClick { get; set; }
        public int LeftButtonDoubleClick { get; set; }
        public int MiddleButtonClick { get; set; }
        public int MiddleButtonDoubleClick { get; set; }
        public int MouseWheel { get; set; }

        public int RightButtonClick { get; set; }
        public int RightButtonDoubleClick { get; set; }


        public void SaveMouseIntoWeb(MouseModel model)
        {
            var mouse = new MouseBusinessObject().ConvertToEntity(new MouseBusinessObject
            {
                TotalClicks = model.TotalClicks,
                LeftButtonClick = model.LeftButtonClick,
                LeftButtonDoubleClick = model.LeftButtonDoubleClick,
                RightButtonClick = model.RightButtonClick,
                RightButtonDoubleClick = model.RightButtonDoubleClick,
                MiddleButtonClick = model.MiddleButtonClick,
                MiddleButtonDoubleClick = model.MiddleButtonDoubleClick,
                MouseWheel = model.MouseWheel
            });
            _mouseWebService.SaveMouseIntoWeb(mouse);
        }
    }
}
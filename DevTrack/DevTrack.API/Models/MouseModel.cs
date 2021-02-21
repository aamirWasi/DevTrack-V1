using Autofac;
using DevTrack.Foundation.BusinessObjects;
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

        public int TotalClicks { get; set; }
        public int LeftButtonClick { get; set; }
        public int LeftButtonDoubleClick { get; set; }
        public int MiddleButtonClick { get; set; }
        public int MiddleButtonDoubleClick { get; set; }
        public int MouseWheel { get; set; }

        public int RightButtonClick { get; set; }
        public int RightButtonDoubleClick { get; set; }


        public void SaveMouseIntoWeb()
        {
            var mouse = new MouseBusinessObject().ConvertToEntity(new MouseBusinessObject
            {
                TotalClicks = TotalClicks,
                LeftButtonClick = LeftButtonClick,
                LeftButtonDoubleClick = LeftButtonDoubleClick,
                RightButtonClick = RightButtonClick,
                RightButtonDoubleClick = RightButtonDoubleClick,
                MiddleButtonClick = MiddleButtonClick,
                MiddleButtonDoubleClick = MiddleButtonDoubleClick,
                MouseWheel = MouseWheel
            });
            _mouseWebService.SaveMouseIntoWeb(mouse);
        }
    }
}
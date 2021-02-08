using System;
using EO = DevTrack.Foundation.Entities;

namespace DevTrack.Foundation.BusinessObjects
{
    public class MouseBusinessObject
    {
        public Guid Id { get; set; }
        public int TotalClicks { get; set; }
        public int LeftButtonClick { get; set; }
        public int LeftButtonDoubleClick { get; set; }
        public int MiddleButtonClick { get; set; }
        public int MiddleButtonDoubleClick { get; set; }
        public int MouseWheel { get; set; }

        public int RightButtonClick { get; set; }
        public int RightButtonDoubleClick { get; set; }

        public EO.Mouse ConvertToEntity(MouseBusinessObject mouseBusiness)
        {
            return new EO.Mouse()
            {
                TotalClicks = mouseBusiness.TotalClicks,
                LeftButtonClick = mouseBusiness.LeftButtonClick,
                LeftButtonDoubleClick = mouseBusiness.LeftButtonDoubleClick,
                RightButtonClick = mouseBusiness.RightButtonClick,
                RightButtonDoubleClick = mouseBusiness.RightButtonDoubleClick,
                MiddleButtonClick = mouseBusiness.MiddleButtonClick,
                MiddleButtonDoubleClick = mouseBusiness.MiddleButtonDoubleClick,
                MouseWheel = mouseBusiness.MouseWheel
            };
        }
    }
}

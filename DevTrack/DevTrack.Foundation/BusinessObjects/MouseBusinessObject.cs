using System;

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
        public int RightButtonClick { get; set; }
        public int RightButtonDoubleClick { get; set; }
    }
}

using DevTrack.DataAccessLayer;
using System;

namespace DevTrack.Foundation.Entities
{
    public class Mouse : IEntity<Guid>
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

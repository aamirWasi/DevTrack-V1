using DevTrack.DataAccessLayer;
using System;

namespace DevTrack.Foundation.Entities
{
    public class WebCamCaptureEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string WebCamImagePath { get; set; }

        public DateTime WebCamImageDateTime { get; set; }
    }
}

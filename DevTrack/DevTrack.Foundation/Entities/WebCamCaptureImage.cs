using DevTrack.DataAccessLayer;
using System;

namespace DevTrack.Foundation.Entities
{
    public class WebCamCaptureImage : IEntity<int>
    {
        public int Id { get; set; }

        public string WebCamImagePath { get; set; }

        public DateTimeOffset WebCamImageDateTime { get; set; }
    }
}

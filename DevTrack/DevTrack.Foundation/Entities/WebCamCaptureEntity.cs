using DevTrack.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTrack.Foundation.Entities
{
    public class WebCamCaptureEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string WebCamImagePath { get; set; }

        public DateTime WebCamImageDateTime { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.BusinessObjects
{
    public class SnapshotImage
    {
        public DateTimeOffset CapturerTime { get; set; }
        public IFormFile Image { get; set; }
    }
}

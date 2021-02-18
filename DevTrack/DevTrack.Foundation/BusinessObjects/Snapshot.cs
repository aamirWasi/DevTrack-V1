using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrack.Foundation.BusinessObjects
{
    public class Snapshot
    {
        public string Location { get; set; }
        public IFormFile FilePath { get; set; }
    }
}

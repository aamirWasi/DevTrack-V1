using DevTrack.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnapshotController : ControllerBase
    {
        [HttpPost]
        public bool Post([FromForm]SnapshotModel model)
        {
            if (model != null)
            {
                model.SaveSnapshot();
                return true;
            }
            else
                return false;
        }
    }
}

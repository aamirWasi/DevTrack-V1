using DevTrack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnapshotController : ControllerBase
    {
        [HttpPost]
        public void Post([FromForm]SnapshotModel model)
        {
            try
            {
                model.SaveSnapshot();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

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
    public class RunningProgramController : ControllerBase
    {
        [HttpPost]
        public void Post(RunningProgramModel model)
        {
            try
            {
                model.SaveRunningPrograms();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

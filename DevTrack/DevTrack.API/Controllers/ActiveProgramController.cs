using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveProgramController : ControllerBase
    {
        [HttpPost]
        public bool Post(ActiveProgramModel model)
        {
            if (model.ProgramName != null)
            {
                model.SaveActiveProgram();
                return true;
            }
            else
                return false;
        }
    }
}

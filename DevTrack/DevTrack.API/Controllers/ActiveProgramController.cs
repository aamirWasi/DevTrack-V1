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
        public void Post(ActiveProgramModel model)
        {
            try
            {
                model.SaveActiveProgram();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

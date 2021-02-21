using Microsoft.AspNetCore.Mvc;
using System;
using DevTrack.API.Models;
using DevTrack.Foundation.Entities;

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] MouseModel model)
        {
            try
            {
                model.SaveMouseIntoWeb();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

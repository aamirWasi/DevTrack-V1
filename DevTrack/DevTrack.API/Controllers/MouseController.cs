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
        public bool Post([FromBody] MouseModel model)
        {
            if (model != null)
            {
                model.SaveMouseIntoWeb(model);
                return true;
            }
            else
                return false;
        }
    }
}

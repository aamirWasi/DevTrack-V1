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
        public void Post([FromForm] Mouse mouse)
        {
            try
            {
                var model = new MouseModel();
                model.SaveMouseIntoWeb(mouse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using DevTrack.API.Models;
using DevTrack.Foundation.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "RestrictedAPI")]
    public class KeyboardController : ControllerBase
    {
        [HttpPost]
        public void Post([FromForm] Keyboard keyboard)
        {
            try
            {
                var model = new KeyboardModel();
                model.SaveKeyboardIntoWeb(keyboard);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

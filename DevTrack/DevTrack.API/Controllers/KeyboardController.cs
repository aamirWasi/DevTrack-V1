using System;
using Microsoft.AspNetCore.Mvc;
using DevTrack.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "RestrictedAPI")]
    public class KeyboardController : ControllerBase
    {
        [HttpPost]
        public bool Post([FromBody] KeyboardModel model)
        {
            try
            {
                model.SaveKeyboardIntoWeb(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

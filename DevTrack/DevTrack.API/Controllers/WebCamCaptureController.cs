using DevTrack.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DevTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebCamCaptureController : ControllerBase
    {
        [HttpPost]
        public bool Post([FromForm]WebCamCaptureModel model)
        {
            try
            {
                model.SaveWebCamCapture();
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }
    }
}

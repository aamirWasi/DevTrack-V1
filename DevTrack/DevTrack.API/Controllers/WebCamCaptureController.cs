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
            if (model != null)
            {
                model.SaveWebCamCapture();
                return true;
            }
            else
                return false;
        }
    }
}

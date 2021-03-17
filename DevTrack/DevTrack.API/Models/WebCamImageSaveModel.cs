using Autofac;
using DevTrack.Membership.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;

namespace DevTrack.API.Models
{
    public class WebCamImageSaveModel : BaseModel
    {
        public WebCamImageSaveModel(string IMAGE_PATH) : base(IMAGE_PATH)
        {

        }
    }
}

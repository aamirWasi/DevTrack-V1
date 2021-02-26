using Autofac;
using DevTrack.Membership.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;

namespace DevTrack.API.Models
{
    public class WebCamImageSaveModel
    {
        protected readonly UserManager<ApplicationUser> _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        private const string IMAGE_PATH = @"images\WebCamCapture";

        public WebCamImageSaveModel()
        {
            _webHostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            _userService = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
        }

        public virtual (string fileName, string filePath) StoreFile(IFormFile file)
        {
            var rootPath = _webHostEnvironment.WebRootPath;
            var newFileName = String.Format(Guid.NewGuid().ToString() + ".jpg");
            var fullPath = Path.Combine(rootPath, IMAGE_PATH);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            var path = Path.Combine(fullPath, newFileName);

            if (!File.Exists(path))
            {
                using var ImageDestination = File.OpenWrite(path);
                using var uploadFile = file.OpenReadStream();
                uploadFile.CopyTo(ImageDestination);
            }
            return (newFileName, path);
        }
    }
}

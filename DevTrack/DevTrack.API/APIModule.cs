using Autofac;
using DevTrack.API.Models;
using Microsoft.AspNetCore.Hosting;

namespace DevTrack.API
{
    public class APIModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public APIModule(string connectionString, string migrationAssemblyName, IWebHostEnvironment webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SnapshotModel>().AsSelf();
            builder.RegisterType<WebCamCaptureModel>().AsSelf();
            builder.RegisterType<KeyboardModel>().AsSelf();
            builder.RegisterType<MouseModel>().AsSelf();
            builder.RegisterType<RunningProgramModel>().AsSelf();

            base.Load(builder);
        }
    }
}

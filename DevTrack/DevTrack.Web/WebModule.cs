using Autofac;
using DevTrack.Web.Areas.Admin.Models;

namespace DevTrack.Web
{
    public class WebModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectCreateModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

using Autofac;
using DevTrack.API.Models;

namespace DevTrack.API
{
    public class ApiModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public ApiModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KeyboardModel>().AsSelf().InstancePerDependency();
            base.Load(builder);
        }
    }
}
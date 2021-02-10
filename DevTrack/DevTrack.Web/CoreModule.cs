using Autofac;

namespace DevTrack.Web
{
    public class CoreModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public CoreModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}

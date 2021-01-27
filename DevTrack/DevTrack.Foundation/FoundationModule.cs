using Autofac;
using DevTrack.Foundation.Services;

namespace DevTrack.Foundation
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RunningProgramService>().As<IRunningProgramService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

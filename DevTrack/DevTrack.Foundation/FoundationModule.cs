using Autofac;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation
{
    public class FoundationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScreenCaptureContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SnapshotRepository>().As<ISnapshotRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SnapshotUnitOfWork>().As<ISnapshotUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotService>().As<ISnapShotService>().InstancePerLifetimeScope();
            builder.RegisterType<LoggerInputService>().As<ILoggerInputService>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramService>().As<IRunningProgramService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

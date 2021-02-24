using Autofac;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Adapters;
using DevTrack.Foundation.UnitOfWorks;

namespace DevTrack.Foundation
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString,string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DevTrackContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<DevTrackWebContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<SnapshotRepository>().As<ISnapshotRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SnapshotUnitOfWork>().As<ISnapshotUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotService>().As<ISnapShotService>().InstancePerLifetimeScope();

            builder.RegisterType<SnapshotWebRepository>().As<ISnapshotWebRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SnapshotWebUnitOfWork>().As<ISnapshotWebUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotWebService>().As<ISnapShotWebService>().InstancePerLifetimeScope();

            builder.RegisterType<SnapshotApiService>().As<ISnapshotApiService>().InstancePerLifetimeScope();
            builder.RegisterType<SnapshotLocalService>().As<ISnapshotLocalService>().InstancePerLifetimeScope();
            builder.RegisterType<Helper>().As<IHelper>().InstancePerLifetimeScope();

            builder.RegisterType<LoggerInputService>().As<ILoggerInputService>().InstancePerLifetimeScope();

            builder.RegisterType<RunningProgramService>().As<IRunningProgramService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramRepository>().As<IRunningProgramRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramUnitOfWork>().As<IRunningProgramUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramAdapter>().As<IRunningProgramAdapter>().InstancePerLifetimeScope();

            builder.RegisterType<WebCamCaptureService>().As<IWebCamCaptureService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureRepository>().As<IWebCamCaptureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureUnitOfWork>().As<IWebCamCaptureUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ActiveProgramRepository>().As<IActiveProgramRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramUnitOfWork>().As<IActiveProgramUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramService>().As<IActiveProgramService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<KeyboardTrackStartService>().As<IKeyboardTrackStartService>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackService>().As<IKeyboardTrackService>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackRepository>().As<IKeyboardTrackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackUnitOfWork>().As<IKeyboardTrackUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<MouseTrackStartService>().As<IMouseTrackStartService>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackService>().As<IMouseTrackService>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackRepository>().As<IMouseTrackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackUnitOfWork>().As<IMouseTrackUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ServerTime>().As<IServerTime>().InstancePerLifetimeScope();
            builder.RegisterType<BitMapAdapter>().As<IBitMapAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotAdapter>().As<ISnapShotAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramAdapter>().As<IActiveProgramAdapter>().InstancePerLifetimeScope();

            builder.RegisterType<WebCamImageAdapter>().As<IWebCamImageAdapter>().InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}

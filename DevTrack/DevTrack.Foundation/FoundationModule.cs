using Autofac;
using DevTrack.Foundation.Adapters;
using DevTrack.Foundation.BusinessObjects;
using DevTrack.Foundation.Contexts;
using DevTrack.Foundation.Repositories;
using DevTrack.Foundation.Repositories.Interfaces;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.UnitOfWorks;
using DevTrack.Foundation.UnitOfWorks.Interfaces;
using DevTrack.Foundation.Services.Interfaces;

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

            builder.RegisterType<SnapshotLocalService>().As<ISnapshotLocalService>().InstancePerLifetimeScope();
            builder.RegisterType<FileManager>().As<IFileManager>().InstancePerLifetimeScope();

            builder.RegisterType<S3FileUploaderService>().As<IS3FileUploaderService>().InstancePerLifetimeScope();

            builder.RegisterType<LoggerInputService>().As<ILoggerInputService>().InstancePerLifetimeScope();

            builder.RegisterType<RunningProgramService>().As<IRunningProgramService>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramRepository>().As<IRunningProgramRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramUnitOfWork>().As<IRunningProgramUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<RunningProgramWebService>().As<IRunningProgramWebService>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramWebRepository>().As<IRunningProgramWebRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramWebUnitOfWork>().As<IRunningProgramWebUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<WebCamCaptureService>().As<IWebCamCaptureService>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureRepository>().As<IWebCamCaptureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureUnitOfWork>().As<IWebCamCaptureUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamImageAdapter>().As<IWebCamImageAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureWebService>().As<IWebCamCaptureWebService>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureWebRepository>().As<IWebCamCaptureWebRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureWebUnitOfWork>().As<IWebCamCaptureWebUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamImageAdapter>().As<IWebCamImageAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureAdapterService>().As<IWebCamCaptureAdapterService>().InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureLocalService>().As<IWebCamCaptureLocalService>().InstancePerLifetimeScope();



            builder.RegisterType<ActiveProgramRepository>().As<IActiveProgramRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramWebRepository>().As<IActiveProgramWebRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramUnitOfWork>().As<IActiveProgramUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramWebUnitOfWork>().As<IActiveProgramWebUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramService>().As<IActiveProgramService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramWebService>().As<IActiveProgramWebService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<KeyboardTrackStartService>().As<IKeyboardTrackStartService>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackService>().As<IKeyboardTrackService>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackRepository>().As<IKeyboardTrackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardTrackUnitOfWork>().As<IKeyboardTrackUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<KeyboardWebRepository>().As<IKeyboardWebRepository>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardWebUnitOfWork>().As<IKeyboardWebUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<KeyboardWebService>().As<IKeyboardWebService>().InstancePerLifetimeScope();

            builder.RegisterType<MouseTrackStartService>().As<IMouseTrackStartService>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackService>().As<IMouseTrackService>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackRepository>().As<IMouseTrackRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MouseTrackUnitOfWork>().As<IMouseTrackUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<MouseWebRepository>().As<IMouseWebRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MouseWebUnitOfWork>().As<IMouseWebUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MouseWebService>().As<IMouseWebService>().InstancePerLifetimeScope();

            builder.RegisterType<ServerTime>().As<IServerTime>().InstancePerLifetimeScope();
            builder.RegisterType<BitMapAdapter>().As<IBitMapAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotWebAdapterService>().As<ISnapShotWebAdapterService>().InstancePerLifetimeScope();
            builder.RegisterType<SnapShotAdapter>().As<ISnapShotAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<ActiveProgramAdapter>().As<IActiveProgramAdapter>().InstancePerLifetimeScope();

            builder.RegisterType<RunningProgramAdapter>().As<IRunningProgramAdapter>().InstancePerLifetimeScope();

            builder.RegisterType<WebCamImageAdapter>().As<IWebCamImageAdapter>().InstancePerLifetimeScope();

            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectUnitOfWork>().As<IProjectUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

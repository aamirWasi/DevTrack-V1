using Autofac;
using DevTrack.Foundation.Services;

namespace DevTrack.Foundation
{
    public class FoundationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SnapShotService>().As<ISnapShotService>().InstancePerLifetimeScope();
            builder.RegisterType<LoggerInputService>().As<ILoggerInputService>().InstancePerLifetimeScope();
            builder.RegisterType<RunningProgramService>().As<IRunningProgramService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<WebCamCaptureService>().As<IWebCamCaptureService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ActiveWindowsService>().As<IActiveWindowsService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

using Autofac;
using DevTrack.Foundation.Services;

namespace DevTrack.TrackerWorkerService
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrackerService>().As<ITrackerService>().SingleInstance();

            builder.RegisterType<WebCamCaptureService>().As<IWebCamCaptureService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
using Autofac;
using DevTrack.Foundation.Services;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.TrackerWorkerService
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrackerService>().As<ITrackerService>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
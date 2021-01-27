using Autofac;
using DevTrack.Foundation.Services;

namespace DevTrack.TrackerWorkerService
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrackerService>().As<ITrackerService>()
                .SingleInstance();

            builder.RegisterType<KeyboardTrackService>().As<IKeyboardTrackService>()
                .SingleInstance();
            builder.RegisterType<MouseTrackService>().As<IMouseTrackService>()
                .SingleInstance();
            builder.RegisterType<KeyboardMouseController>().As<IKeyboardMouseController>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
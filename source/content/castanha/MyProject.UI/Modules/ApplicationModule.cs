namespace MyProject.UI.Modules
{
    using Autofac;
    using MyProject.Application;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MyProject.Application
            //
            // IPublisher
            // ISubscriber
            // IInputBoundary<>
            // IOutputBoundary<>
            // IEventHandler
            //
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

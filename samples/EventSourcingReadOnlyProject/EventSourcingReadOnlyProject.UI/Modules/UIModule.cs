namespace EventSourcingReadOnlyProject.UI.Modules
{
    using Autofac;
    using EventSourcingReadOnlyProject.Application;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in EventSourcingReadOnlyProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

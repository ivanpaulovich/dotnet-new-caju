namespace EventSourcingBasicProject.UI.Modules
{
    using Autofac;
    using EventSourcingBasicProject.Application;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in EventSourcingBasicProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

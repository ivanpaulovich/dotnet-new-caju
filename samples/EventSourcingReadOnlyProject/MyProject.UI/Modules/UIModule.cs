namespace EventSourcingReadOnlyProject.UI.Modules
{
    using Autofac;
    using EventSourcingReadOnlyProject.Application;
    using EventSourcingReadOnlyProject.UI.Presenters;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in EventSourcingReadOnlyProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

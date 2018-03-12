namespace EventSourcingFullProject.UI.Modules
{
    using Autofac;
    using EventSourcingFullProject.Application;
    using EventSourcingFullProject.UI.Presenters;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in EventSourcingFullProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

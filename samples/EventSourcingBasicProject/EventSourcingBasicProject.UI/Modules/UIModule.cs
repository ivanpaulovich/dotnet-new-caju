namespace EventSourcingBasicProject.UI.Modules
{
    using Autofac;
    using EventSourcingBasicProject.Application;
    using EventSourcingBasicProject.UI.Presenters;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in EventSourcingBasicProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

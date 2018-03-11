namespace MyProject.UI.Modules
{
    using Autofac;
    using MyProject.Application;
    using MyProject.UI.Presenters;

    public class UIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Presenters in MyProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(RegisterPresenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

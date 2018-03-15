namespace MyProject.UI.Modules
{
    using MyProject.Application.Commands.Register;
    using Autofac;
    using MyProject.Application;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MyProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(IResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

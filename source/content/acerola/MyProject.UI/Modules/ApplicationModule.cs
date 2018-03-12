namespace MyProject.UI.Modules
{
    using MyProject.Application.Commands.Register;
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MyProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

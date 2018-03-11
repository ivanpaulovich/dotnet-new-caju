namespace Hexagonal_ReadOnlyProject.UI.Modules
{
    using Hexagonal_ReadOnlyProject.Application.Commands.Register;
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Hexagonal_ReadOnlyProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

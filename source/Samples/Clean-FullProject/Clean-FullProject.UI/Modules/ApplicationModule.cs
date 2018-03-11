namespace Clean_FullProject.UI.Modules
{
    using Clean_FullProject.Application.Commands.Register;
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Clean_FullProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

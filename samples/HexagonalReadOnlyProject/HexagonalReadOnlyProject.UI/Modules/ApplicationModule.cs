namespace HexagonalReadOnlyProject.UI.Modules
{
    using HexagonalReadOnlyProject.Application.Commands.Register;
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in HexagonalReadOnlyProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

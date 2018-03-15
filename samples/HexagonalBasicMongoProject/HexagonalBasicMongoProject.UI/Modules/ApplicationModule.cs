namespace HexagonalBasicMongoProject.UI.Modules
{
    using HexagonalBasicMongoProject.Application.Commands.Register;
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in HexagonalBasicMongoProject.Application
            //
            builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

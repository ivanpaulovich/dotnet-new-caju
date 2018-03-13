namespace HexagonalBasicWithoutInfraProject.UI.Modules
{
    using Autofac;
    using HexagonalBasicWithoutInfraProject.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            //
            // Register all Types in HexagonalBasicWithoutInfraProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}

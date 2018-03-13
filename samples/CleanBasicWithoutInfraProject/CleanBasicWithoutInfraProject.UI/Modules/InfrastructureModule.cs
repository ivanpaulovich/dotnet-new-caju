namespace CleanBasicWithoutInfraProject.UI.Modules
{
    using Autofac;
    using CleanBasicWithoutInfraProject.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            //
            // Register all Types in CleanBasicWithoutInfraProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(ResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

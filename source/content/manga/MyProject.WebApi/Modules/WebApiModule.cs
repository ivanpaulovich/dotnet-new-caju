namespace MyProject.WebApi.Modules
{
    using Autofac;
    using MyProject.Application;

    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in MyProject.WebApi
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

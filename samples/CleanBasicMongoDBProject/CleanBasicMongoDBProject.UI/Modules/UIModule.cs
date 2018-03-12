namespace CleanBasicMongoDBProject.UI.Modules
{
    using Autofac;
    using CleanBasicMongoDBProject.Application;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in CleanBasicMongoDBProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

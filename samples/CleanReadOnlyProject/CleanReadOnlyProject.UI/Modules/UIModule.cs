namespace CleanReadOnlyProject.UI.Modules
{
    using Autofac;
    using CleanReadOnlyProject.Application;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in CleanReadOnlyProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

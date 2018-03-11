namespace Clean_ReadOnlyProject.UI.Modules
{
    using Autofac;
    using Clean_ReadOnlyProject.Application;
    using Clean_ReadOnlyProject.UI.UseCases.Register;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Clean_ReadOnlyProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Presenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

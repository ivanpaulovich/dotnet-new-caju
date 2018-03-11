namespace Clean_BasicProject.UI.Modules
{
    using Autofac;
    using Clean_BasicProject.Application;
    using Clean_BasicProject.UI.UseCases.Register;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Clean_BasicProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Presenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

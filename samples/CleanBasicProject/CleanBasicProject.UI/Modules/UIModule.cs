namespace CleanBasicProject.UI.Modules
{
    using Autofac;
    using CleanBasicProject.Application;
    using CleanBasicProject.UI.UseCases.Register;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in CleanBasicProject.UI
            //
            builder.RegisterAssemblyTypes(typeof(Presenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

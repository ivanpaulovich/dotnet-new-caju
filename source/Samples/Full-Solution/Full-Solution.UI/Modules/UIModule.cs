namespace Full_Solution.UI.Modules
{
    using Autofac;
    using Full_Solution.Application;
    using Full_Solution.UI.UseCases.Register;

    public class UIModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Full_Solution.UI
            //
            builder.RegisterAssemblyTypes(typeof(Presenter).Assembly)
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}

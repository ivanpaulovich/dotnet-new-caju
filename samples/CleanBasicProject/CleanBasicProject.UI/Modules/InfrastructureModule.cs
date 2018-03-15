namespace CleanBasicProject.UI.Modules
{
    using Autofac;
    using CleanBasicProject.Infrastructure.DataAccess.Mongo;
    using CleanBasicProject.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            //
            // Register all Types in CleanBasicProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

namespace MyProject.UI.Modules
{
    using Autofac;
    using MyProject.Infrastructure.DataAccess;

    public class InfrastructureModule : Autofac.Module
    {
#if (MongoDB)
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
#endif

        protected override void Load(ContainerBuilder builder)
        {
#if (MongoDB)
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            //
            // Register all Types in MyProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
#endif
        }
    }
}

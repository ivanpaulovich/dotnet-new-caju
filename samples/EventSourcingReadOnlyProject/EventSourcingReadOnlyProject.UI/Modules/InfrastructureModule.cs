namespace EventSourcingReadOnlyProject.UI.Modules
{
    using Autofac;
    using EventSourcingReadOnlyProject.Application.ServiceBus;
    using EventSourcingReadOnlyProject.Infrastructure.DataAccess;
    using EventSourcingReadOnlyProject.Infrastructure.ServiceBus;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in EventSourcingReadOnlyProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
        }
    }
}

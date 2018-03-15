namespace EventSourcingFullProject.UI.Modules
{
    using Autofac;
    using EventSourcingFullProject.Application.ServiceBus;
    using EventSourcingFullProject.Infrastructure.DataAccess;
    using EventSourcingFullProject.Infrastructure.ServiceBus;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in EventSourcingFullProject.Infrastructure
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

namespace EventSourcingBasicProject.UI.Modules
{
    using Autofac;
    using EventSourcingBasicProject.Application.ServiceBus;
    using EventSourcingBasicProject.Infrastructure.DataAccess;
    using EventSourcingBasicProject.Infrastructure.ServiceBus;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in EventSourcingBasicProject.Infrastructure
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

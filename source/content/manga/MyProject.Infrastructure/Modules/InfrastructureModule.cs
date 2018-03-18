namespace MyProject.Infrastructure.Modules
{
    using Autofac;
#if Mongo
    using MyProject.Infrastructure.DataAccess.Mongo;
#endif
    using MyProject.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
#if (Mongo)
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
#endif

        protected override void Load(ContainerBuilder builder)
        {
#if (Mongo)
            builder.RegisterType<AccountBalanceContext>()
                .As<AccountBalanceContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
#endif

            //
            // Register all Types in MyProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

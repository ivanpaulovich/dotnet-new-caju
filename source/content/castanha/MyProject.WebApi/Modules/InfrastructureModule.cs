namespace MyProject.WebApi.Modules
{
    using Autofac;
    using MyProject.Infrastructure.Mappings;
#if Mongo
    using MyProject.Infrastructure.DataAccess.Mongo;
#endif

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

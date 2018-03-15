namespace HexagonalBasicProject.UI.Modules
{
    using Autofac;
    using HexagonalBasicProject.Infrastructure.Mongo;
    using HexagonalBasicProject.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoContext>()
                .As<MongoContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            //
            // Register all Types in HexagonalBasicProject.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(ResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

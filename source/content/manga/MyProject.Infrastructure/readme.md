## **4\. Frameworks & Drivers**

Our more external layer is the Frameworks & Drivers who implements Data Base Access, Dependency Injection Framework (DI), JSON Serializer and technology specific stuff.

It has an CustomerRepository implementation. See the GitHub for the MongoContext and other Repositories classes.
    
    
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context mongoContext;
    
        public CustomerRepository(Context mongoContext)
        {
            this.mongoContext = mongoContext;
        }
    
        public async Task Get(Guid customerId)
        {
            Customer customer = await mongoContext.Customers
                .Find(e => e.Id == customerId)
                .SingleOrDefaultAsync();
    
            return customer;
        }
    
        public async Task Add(Customer customer)
        {
            await mongoContext.Customers
                .InsertOneAsync(customer);
        }
    
        public async Task Update(Customer customer)
        {
            await mongoContext.Customers
                .ReplaceOneAsync(e => e.Id == customer.Id, customer);
        }
    }

We group the DI by Autofac Modules and created rules for selecting the interfaces and implementations by namespace patterns.
    
    
    public class InfrastructureModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType()
                .As()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
    
            //
            // Register all Types in Manga.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }

And finally everything is tied together with configurations in the **autofac.json** which also makes possible to change implementations easily:
    
    
    {
      "defaultAssembly": "Manga.Infrastructure",
      "modules": [
        {
          "type": "Manga.Infrastructure.Modules.WebApiModule",
          "properties": {
          }
        },
        {
          "type": "Manga.Infrastructure.Modules.ApplicationModule",
          "properties": {
          }
        },
        {
          "type": "Manga.Infrastructure.Modules.InfrastructureModule",
          "properties": {
            "ConnectionString": "mongodb://10.0.75.1:27017",
            "DatabaseName": "Manga-V01"
          }
        }
      ]
    }

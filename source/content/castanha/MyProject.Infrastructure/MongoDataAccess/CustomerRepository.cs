namespace MyProject.Infrastructure.MongoDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using MyProject.Domain.Customers.Events;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly AccountBalanceContext mongoContext;

        public CustomerRepository(AccountBalanceContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task<Customer> Get(Guid customerId)
        {
            Customer customer = await mongoContext.Customers
                .Find(e => e.Id == customerId)
                .SingleOrDefaultAsync();

            return customer;
        }

        public async Task Add(RegisteredDomainEvent domainEvent)
        {
            Customer customer = new Customer();
            customer.Apply(domainEvent);

            await mongoContext.Customers
                .InsertOneAsync(customer);
        }
    }
}

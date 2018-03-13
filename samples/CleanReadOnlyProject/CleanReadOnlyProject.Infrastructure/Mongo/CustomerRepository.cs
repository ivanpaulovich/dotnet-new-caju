namespace CleanReadOnlyProject.Infrastructure.Mongo
{
    using CleanReadOnlyProject.Application.Repositories;
    using CleanReadOnlyProject.Domain.Customers;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly MongoContext mongoContext;

        public CustomerRepository(MongoContext mongoContext)
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
}

namespace MyReadOnly.Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using MyReadOnly.Application.Repositories;
    using MyReadOnly.Domain.Customers;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MyReadOnlyContext _context;

        public CustomerRepository(MyReadOnlyContext context)
        {
            _context = context;
        }

        public async Task Add(ICustomer customer)
        {
            _context.Customers.Add((InMemoryDataAccess.Customer) customer);
            await Task.CompletedTask;
        }

        public async Task<ICustomer> Get(Guid id)
        {
            Customer customer = _context.Customers
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return await Task.FromResult<Customer>(customer);
        }

        public async Task Update(ICustomer customer)
        {
            Customer customerOld = _context.Customers
                .Where(e => e.Id == customer.Id)
                .SingleOrDefault();

            customerOld = (Customer) customer;
            await Task.CompletedTask;
        }
    }
}
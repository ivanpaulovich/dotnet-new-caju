namespace MyProject.Infrastructure.EntityFrameworkDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using MyProject.Domain.Customers.Events;
    using System;
    using System.Threading.Tasks;
    using System.Linq;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context context;

        public CustomerRepository(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(RegisteredDomainEvent domainEvent)
        {
            Customer customer = new Customer();
            customer.Apply(domainEvent);
            await context.Customers.AddAsync(customer);
            int affectedRows = await context.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            Customer customer = await context.Customers.FindAsync(id);
            var accounts = context
                .Accounts
                .Where(p => p.CustomerId == id)
                .Select(e => e.Id)
                .ToList();

            Proxies.Customer customerProxy = new Proxies.Customer(customer, accounts);
            return customerProxy;
        }
    }
}

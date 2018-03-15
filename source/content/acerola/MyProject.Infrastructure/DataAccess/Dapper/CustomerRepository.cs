namespace MyProject.Infrastructure.DataAccess.Dapper
{
    using MyProject.Application.Repositories;
    using System;
    using MyProject.Domain.Customers;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        public Task Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

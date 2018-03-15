namespace MyProject.Infrastructure.DataAccess.Dapper
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        public Task<Customer> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

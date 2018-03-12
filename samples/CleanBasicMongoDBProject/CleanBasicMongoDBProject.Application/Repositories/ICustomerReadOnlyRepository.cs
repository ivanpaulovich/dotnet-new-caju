namespace CleanBasicMongoDBProject.Application.Repositories
{
    using CleanBasicMongoDBProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

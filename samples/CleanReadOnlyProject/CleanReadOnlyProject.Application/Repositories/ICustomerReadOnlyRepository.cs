namespace CleanReadOnlyProject.Application.Repositories
{
    using CleanReadOnlyProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

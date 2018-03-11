namespace Hexagonal_BasicProject.Application.Repositories
{
    using Hexagonal_BasicProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

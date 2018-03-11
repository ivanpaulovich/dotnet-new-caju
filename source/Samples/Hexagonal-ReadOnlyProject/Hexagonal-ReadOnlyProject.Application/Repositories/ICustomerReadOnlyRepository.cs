namespace Hexagonal_ReadOnlyProject.Application.Repositories
{
    using Hexagonal_ReadOnlyProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

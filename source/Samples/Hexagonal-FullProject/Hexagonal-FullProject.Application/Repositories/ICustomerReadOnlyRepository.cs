namespace Hexagonal_FullProject.Application.Repositories
{
    using Hexagonal_FullProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

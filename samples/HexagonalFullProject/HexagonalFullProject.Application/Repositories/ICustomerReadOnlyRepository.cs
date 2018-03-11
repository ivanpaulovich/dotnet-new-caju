namespace HexagonalFullProject.Application.Repositories
{
    using HexagonalFullProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

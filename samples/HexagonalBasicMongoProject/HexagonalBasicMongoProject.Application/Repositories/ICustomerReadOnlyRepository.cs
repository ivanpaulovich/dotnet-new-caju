namespace HexagonalBasicMongoProject.Application.Repositories
{
    using HexagonalBasicMongoProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

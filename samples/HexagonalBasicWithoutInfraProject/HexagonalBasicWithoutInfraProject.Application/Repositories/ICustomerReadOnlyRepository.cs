namespace HexagonalBasicWithoutInfraProject.Application.Repositories
{
    using HexagonalBasicWithoutInfraProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

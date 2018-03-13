namespace HexagonalBasicMongoProject.Application.Queries
{
    using HexagonalBasicMongoProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

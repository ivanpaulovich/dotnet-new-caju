namespace HexagonalBasicProject.Application.Queries
{
    using HexagonalBasicProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

namespace HexagonalReadOnlyProject.Application.Queries
{
    using HexagonalReadOnlyProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

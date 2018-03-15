namespace HexagonalReadOnlyProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalReadOnlyProject.Application.Queries;
    using System;
    using HexagonalReadOnlyProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

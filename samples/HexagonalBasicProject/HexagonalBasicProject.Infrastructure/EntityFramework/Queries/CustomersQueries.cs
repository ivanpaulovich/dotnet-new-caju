namespace HexagonalBasicProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalBasicProject.Application.Queries;
    using System;
    using HexagonalBasicProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

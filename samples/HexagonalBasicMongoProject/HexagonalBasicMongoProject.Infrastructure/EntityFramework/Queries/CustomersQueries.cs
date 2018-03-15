namespace HexagonalBasicMongoProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalBasicMongoProject.Application.Queries;
    using System;
    using HexagonalBasicMongoProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

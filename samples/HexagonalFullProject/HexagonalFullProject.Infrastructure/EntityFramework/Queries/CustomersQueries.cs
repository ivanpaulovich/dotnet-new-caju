namespace HexagonalFullProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalFullProject.Application.Queries;
    using System;
    using HexagonalFullProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

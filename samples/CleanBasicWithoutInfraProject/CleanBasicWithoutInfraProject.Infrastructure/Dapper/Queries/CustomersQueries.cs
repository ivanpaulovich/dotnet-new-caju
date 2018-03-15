namespace CleanBasicWithoutInfraProject.Infrastructure.Dapper.Queries
{
    using CleanBasicWithoutInfraProject.Application.Queries;
    using System;
    using CleanBasicWithoutInfraProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

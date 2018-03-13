namespace MyProject.Infrastructure.EntityFramework.Queries
{
    using MyProject.Application.Queries;
    using System;
    using MyProject.Application.Results;
    using System.Threading.Tasks;

    public class CustomersQueries : ICustomersQueries
    {
        public Task<CustomerResult> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

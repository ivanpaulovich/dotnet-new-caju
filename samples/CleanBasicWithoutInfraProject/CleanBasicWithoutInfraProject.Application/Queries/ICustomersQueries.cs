namespace CleanBasicWithoutInfraProject.Application.Queries
{
    using CleanBasicWithoutInfraProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

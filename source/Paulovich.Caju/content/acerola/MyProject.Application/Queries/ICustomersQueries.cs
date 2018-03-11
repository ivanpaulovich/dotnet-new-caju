namespace MyProject.Application.Queries
{
    using MyProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

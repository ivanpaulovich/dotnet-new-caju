namespace Hexagonal_BasicProject.Application.Queries
{
    using Hexagonal_BasicProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

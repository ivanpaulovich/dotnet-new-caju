namespace Hexagonal_ReadOnlyProject.Application.Queries
{
    using Hexagonal_ReadOnlyProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}

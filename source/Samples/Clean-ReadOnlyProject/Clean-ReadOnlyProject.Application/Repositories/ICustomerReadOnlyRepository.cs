namespace Clean_ReadOnlyProject.Application.Repositories
{
    using Clean_ReadOnlyProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

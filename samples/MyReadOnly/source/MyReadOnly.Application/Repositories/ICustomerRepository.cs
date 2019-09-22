namespace MyReadOnly.Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using MyReadOnly.Domain.Customers;

    public interface ICustomerRepository
    {
        Task<ICustomer> Get(Guid id);
        Task Add(ICustomer customer);
        Task Update(ICustomer customer);
    }
}
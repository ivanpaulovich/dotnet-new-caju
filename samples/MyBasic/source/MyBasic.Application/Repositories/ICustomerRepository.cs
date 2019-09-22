namespace MyBasic.Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using MyBasic.Domain.Customers;

    public interface ICustomerRepository
    {
        Task<ICustomer> Get(Guid id);
        Task Add(ICustomer customer);
        Task Update(ICustomer customer);
    }
}
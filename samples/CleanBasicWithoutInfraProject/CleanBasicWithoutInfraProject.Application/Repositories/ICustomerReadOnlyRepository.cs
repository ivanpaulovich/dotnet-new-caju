namespace CleanBasicWithoutInfraProject.Application.Repositories
{
    using CleanBasicWithoutInfraProject.Domain.Customers;
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}

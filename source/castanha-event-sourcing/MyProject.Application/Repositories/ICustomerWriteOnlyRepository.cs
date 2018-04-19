namespace MyProject.Application.Repositories
{
    using MyProject.Domain.Customers;
    using MyProject.Domain.Customers.Events;
    using System.Threading.Tasks;

    public interface ICustomerWriteOnlyRepository
    {
        Task Add(RegisteredDomainEvent domainEvent);
    }
}

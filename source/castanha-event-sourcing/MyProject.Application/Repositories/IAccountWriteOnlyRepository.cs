namespace MyProject.Application.Repositories
{
    using MyProject.Domain.Accounts;
    using MyProject.Domain.Accounts.Events;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(OpenedDomainEvent domainEvent);
        Task Update(DepositedDomainEvent domainEvent);
        Task Update(WithdrewDomainEvent domainEvent);
        Task Delete(ClosedDomainEvent domainEvent);
    }
}

namespace EventSourcingReadOnlyProject.Application.Repositories
{
    using EventSourcingReadOnlyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

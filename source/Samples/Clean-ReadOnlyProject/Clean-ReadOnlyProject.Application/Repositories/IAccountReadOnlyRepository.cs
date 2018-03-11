namespace Clean_ReadOnlyProject.Application.Repositories
{
    using Clean_ReadOnlyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

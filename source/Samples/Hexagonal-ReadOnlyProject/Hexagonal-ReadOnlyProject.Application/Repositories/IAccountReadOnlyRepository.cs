namespace Hexagonal_ReadOnlyProject.Application.Repositories
{
    using Hexagonal_ReadOnlyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

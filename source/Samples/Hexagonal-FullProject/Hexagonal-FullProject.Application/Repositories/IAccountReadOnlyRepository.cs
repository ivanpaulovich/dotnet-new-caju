namespace Hexagonal_FullProject.Application.Repositories
{
    using Hexagonal_FullProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

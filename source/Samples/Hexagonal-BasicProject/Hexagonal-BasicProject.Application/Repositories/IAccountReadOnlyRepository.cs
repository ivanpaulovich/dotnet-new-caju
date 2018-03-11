namespace Hexagonal_BasicProject.Application.Repositories
{
    using Hexagonal_BasicProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

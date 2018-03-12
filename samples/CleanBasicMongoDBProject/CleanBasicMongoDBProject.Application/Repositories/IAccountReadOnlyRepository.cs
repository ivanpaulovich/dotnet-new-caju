namespace CleanBasicMongoDBProject.Application.Repositories
{
    using CleanBasicMongoDBProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

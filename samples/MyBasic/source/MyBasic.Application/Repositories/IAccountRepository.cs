namespace MyBasic.Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using MyBasic.Domain.Accounts;

    public interface IAccountRepository
    {
        Task<IAccount> Get(Guid id);
        Task Add(IAccount account, ICredit credit);
        Task Update(IAccount account, ICredit credit);
        Task Update(IAccount account, IDebit debit);
        Task Delete(IAccount account);
    }
}
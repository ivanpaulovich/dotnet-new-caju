namespace MyProject.Infrastructure.DataAccess.Dapper
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository
    {
        public Task<Account> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

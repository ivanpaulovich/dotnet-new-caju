namespace MyProject.Infrastructure.Dapper.EntityFramework.Queries
{
    using MyProject.Application.Queries;
    using System;
    using MyProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

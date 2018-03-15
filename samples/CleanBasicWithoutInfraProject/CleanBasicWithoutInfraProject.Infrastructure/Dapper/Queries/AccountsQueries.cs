namespace CleanBasicWithoutInfraProject.Infrastructure.Dapper.Queries
{
    using CleanBasicWithoutInfraProject.Application.Queries;
    using System;
    using CleanBasicWithoutInfraProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

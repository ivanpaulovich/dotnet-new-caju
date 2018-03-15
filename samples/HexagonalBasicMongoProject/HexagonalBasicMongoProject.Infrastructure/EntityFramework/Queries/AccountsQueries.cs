namespace HexagonalBasicMongoProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalBasicMongoProject.Application.Queries;
    using System;
    using HexagonalBasicMongoProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

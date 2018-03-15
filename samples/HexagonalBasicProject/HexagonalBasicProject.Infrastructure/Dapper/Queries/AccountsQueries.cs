namespace HexagonalBasicProject.Infrastructure.Dapper.Queries
{
    using HexagonalBasicProject.Application.Queries;
    using System;
    using HexagonalBasicProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

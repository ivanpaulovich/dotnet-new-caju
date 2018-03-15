namespace HexagonalFullProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalFullProject.Application.Queries;
    using System;
    using HexagonalFullProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

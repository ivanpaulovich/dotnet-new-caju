namespace HexagonalReadOnlyProject.Infrastructure.EntityFramework.Queries
{
    using HexagonalReadOnlyProject.Application.Queries;
    using System;
    using HexagonalReadOnlyProject.Application.Results;
    using System.Threading.Tasks;

    class AccountsQueries : IAccountsQueries
    {
        public Task<AccountResult> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

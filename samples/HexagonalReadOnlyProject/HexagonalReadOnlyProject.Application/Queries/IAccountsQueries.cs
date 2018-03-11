namespace HexagonalReadOnlyProject.Application.Queries
{
    using HexagonalReadOnlyProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

namespace HexagonalBasicProject.Application.Queries
{
    using HexagonalBasicProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

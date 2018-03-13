namespace HexagonalBasicMongoProject.Application.Queries
{
    using HexagonalBasicMongoProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

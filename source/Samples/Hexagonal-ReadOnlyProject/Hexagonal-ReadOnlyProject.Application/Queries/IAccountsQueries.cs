namespace Hexagonal_ReadOnlyProject.Application.Queries
{
    using Hexagonal_ReadOnlyProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

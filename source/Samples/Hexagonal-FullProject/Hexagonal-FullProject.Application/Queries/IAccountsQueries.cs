namespace Hexagonal_FullProject.Application.Queries
{
    using Hexagonal_FullProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

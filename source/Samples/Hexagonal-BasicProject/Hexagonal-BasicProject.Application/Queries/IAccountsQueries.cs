namespace Hexagonal_BasicProject.Application.Queries
{
    using Hexagonal_BasicProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

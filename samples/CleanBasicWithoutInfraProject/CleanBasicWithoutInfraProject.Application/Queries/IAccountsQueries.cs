namespace CleanBasicWithoutInfraProject.Application.Queries
{
    using CleanBasicWithoutInfraProject.Application.Results;
    using System;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountResult> GetAccount(Guid id);
    }
}

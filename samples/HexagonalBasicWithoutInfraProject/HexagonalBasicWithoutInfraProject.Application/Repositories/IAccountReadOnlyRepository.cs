namespace HexagonalBasicWithoutInfraProject.Application.Repositories
{
    using HexagonalBasicWithoutInfraProject.Domain.Accounts;
    using System;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);        
    }
}

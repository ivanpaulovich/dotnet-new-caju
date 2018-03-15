namespace HexagonalBasicMongoProject.Infrastructure.EntityFramework
{
    using HexagonalBasicMongoProject.Application.Repositories;
    using System;
    using HexagonalBasicMongoProject.Domain.Accounts;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        public Task Add(Account account)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}

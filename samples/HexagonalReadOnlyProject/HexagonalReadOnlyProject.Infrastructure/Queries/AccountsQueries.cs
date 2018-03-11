namespace HexagonalReadOnlyProject.Infrastructure.Queries
{
    using HexagonalReadOnlyProject.Application.Queries;
    using HexagonalReadOnlyProject.Application.Results;
    using HexagonalReadOnlyProject.Infrastructure.DataAccess;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using HexagonalReadOnlyProject.Application;
    using HexagonalReadOnlyProject.Domain.Accounts;

    public class AccountsQueries : IAccountsQueries
    {
        private readonly AccountBalanceContext mongoDB;
        private readonly IResultConverter mapper;

        public AccountsQueries(AccountBalanceContext mongoDB, IResultConverter mapper)
        {
            this.mongoDB = mongoDB;
            this.mapper = mapper;
        }

        public async Task<AccountResult> GetAccount(Guid accountId)
        {
            Account data = await mongoDB
                .Accounts
                .Find(e => e.Id == accountId)
                .SingleOrDefaultAsync();

            if (data == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists or is not processed yet.");

            AccountResult accountResult = this.mapper.Map<AccountResult>(data);

            return accountResult;
        }
    }
}

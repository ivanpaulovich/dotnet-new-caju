namespace Hexagonal_FullProject.Infrastructure.Queries
{
    using Hexagonal_FullProject.Application.Queries;
    using Hexagonal_FullProject.Application.Results;
    using Hexagonal_FullProject.Infrastructure.DataAccess;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using Hexagonal_FullProject.Application;
    using Hexagonal_FullProject.Domain.Accounts;

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

namespace MyProject.Infrastructure.MongoDataAccess.Queries
{
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using MyProject.Application;
    using MyProject.Application.Queries;
    using MyProject.Application.Results;
    using MyProject.Domain.Accounts;

    public class AccountsQueries : IAccountsQueries
    {
        private readonly Context context;
        private readonly IResultConverter mapper;

        public AccountsQueries(Context context, IResultConverter mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AccountResult> GetAccount(Guid accountId)
        {
            Account data = await context
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

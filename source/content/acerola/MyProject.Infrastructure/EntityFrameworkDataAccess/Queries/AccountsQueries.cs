namespace test01.Infrastructure.MongoDataAccess.Queries
{
    using System;
    using System.Threading.Tasks;
    using test01.Application;
    using test01.Application.Queries;
    using test01.Application.Results;
    using test01.Infrastructure.EntityFrameworkDataAccess;

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
            var account = await context.Accounts.FindAsync(accountId);

            if (account == null)
                return null;

            await context.Entry(account)
                .Collection(i => i.Transactions)
                .LoadAsync();

            AccountResult accountResult = this.mapper.Map<AccountResult>(account);

            return accountResult;
        }
    }
}

namespace MyProject.Infrastructure.MongoDataAccess.Queries
{
    using System;
    using System.Threading.Tasks;
    using MyProject.Application;
    using MyProject.Application.Queries;
    using MyProject.Application.Results;
    using MyProject.Infrastructure.EntityFrameworkDataAccess;

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

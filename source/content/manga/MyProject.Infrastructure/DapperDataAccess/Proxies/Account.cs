namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using MyProject.Domain.Accounts;
    using System.Collections.Generic;

    internal class Account : Domain.Accounts.Account
    {
        public Account(Domain.Accounts.Account account, IEnumerable<Transaction> transactions)
        {
            this.Id = account.Id;
            this.CustomerId = account.CustomerId;
            this.Version = account.Version;
            this.Transactions = new TransactionCollection(transactions);
        }
    }
}

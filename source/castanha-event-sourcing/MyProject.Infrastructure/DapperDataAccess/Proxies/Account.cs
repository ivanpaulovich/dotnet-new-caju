namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using MyProject.Domain.Accounts;
    using System.Collections.Generic;

    internal class Account : Domain.Accounts.Account
    {
        public void SetTransactions(IEnumerable<Transaction> transactions)
        {
            Transactions = new Domain.Accounts.TransactionCollection(transactions);
        }
    }
}

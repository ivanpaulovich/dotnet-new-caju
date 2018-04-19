namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using System;
    using System.Collections.Generic;

    internal class Customer : Domain.Customers.Customer
    {
        public void SetAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new Domain.Customers.AccountCollection(accounts);
        }
    }
}

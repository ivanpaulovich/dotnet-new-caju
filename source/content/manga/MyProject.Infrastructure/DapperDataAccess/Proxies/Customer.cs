namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using MyProject.Domain.Customers;
    using System;
    using System.Collections.Generic;

    internal class Customer : Domain.Customers.Customer
    {
        public Customer(Domain.Customers.Customer customer, IEnumerable<Guid> accounts)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.PIN = customer.PIN;
            this.Accounts = new AccountCollection(accounts);
            this.Version = customer.Version;
        }
    }
}

namespace MyBasic.Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using MyBasic.Domain.Customers;
    using MyBasic.Domain.ValueObjects;

    public class Customer : MyBasic.Domain.Customers.Customer
    {
        public Customer() { }

        public Customer(SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
        }

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}
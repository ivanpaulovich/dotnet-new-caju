namespace MyBasic.Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using MyBasic.Domain.Accounts;
    using MyBasic.Domain.Customers;

    public class Account : MyBasic.Domain.Accounts.Account
    {
        public Guid CustomerId { get; protected set; }

        protected Account() { }

        public Account(ICustomer customer)
        {
            Id = Guid.NewGuid();
            CustomerId = customer.Id;
        }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            Credits = new CreditsCollection();
            Credits.Add(credits);

            Debits = new DebitsCollection();
            Debits.Add(debits);
        }
    }
}
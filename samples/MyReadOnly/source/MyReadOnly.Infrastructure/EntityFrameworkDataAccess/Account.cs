namespace MyReadOnly.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Collections.Generic;
    using MyReadOnly.Domain.Accounts;
    using MyReadOnly.Domain.Customers;

    public class Account : MyReadOnly.Domain.Accounts.Account
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
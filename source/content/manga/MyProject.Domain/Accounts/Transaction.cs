namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System;

    public abstract class Transaction : Entity
    {
        public virtual Amount Amount { get; protected set; }
        public virtual DateTime TransactionDate { get; protected set; }
        public abstract string Description { get; }

        protected Transaction()
        {

        }

        protected Transaction(Amount amount)
        {
            Amount = amount;
            TransactionDate = DateTime.Now;
        }
    }
}

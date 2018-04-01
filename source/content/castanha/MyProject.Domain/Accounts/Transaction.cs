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

        public Transaction(Amount amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
        }

        public Transaction(Amount amount, DateTime transactionDate)
            : this(amount)
        {
            TransactionDate = transactionDate;
        }
    }
}

namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System;

    public abstract class Transaction : Entity
    {
        public virtual Amount Amount { get; protected set; }
        public virtual DateTime TransactionDate { get; protected set; }
        public virtual Guid AccountId { get; protected set; }
        public abstract string Description { get; }

        protected Transaction()
        {

        }

        public Transaction(Guid accountId, Amount amount)
        {
            AccountId = accountId;
            TransactionDate = DateTime.Now;
            Amount = amount;
        }

        public Transaction(Guid accountId, Amount amount, DateTime transactionDate)
            : this(accountId, amount)
        {
            TransactionDate = transactionDate;
        }
    }
}

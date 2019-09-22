namespace MyReadOnly.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using MyReadOnly.Domain.Accounts;
    using MyReadOnly.Domain.ValueObjects;

    public class Debit : MyReadOnly.Domain.Accounts.Debit
    {
        public Guid AccountId { get; protected set; }

        protected Debit() { }

        public Debit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }
    }
}
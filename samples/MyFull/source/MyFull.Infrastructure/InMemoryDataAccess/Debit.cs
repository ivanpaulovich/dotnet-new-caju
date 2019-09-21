namespace MyFull.Infrastructure.InMemoryDataAccess
{
    using System;
    using MyFull.Domain.Accounts;
    using MyFull.Domain.ValueObjects;

    public class Debit : MyFull.Domain.Accounts.Debit
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
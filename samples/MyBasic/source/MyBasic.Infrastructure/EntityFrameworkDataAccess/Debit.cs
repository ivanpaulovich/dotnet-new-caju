namespace MyBasic.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using MyBasic.Domain.Accounts;
    using MyBasic.Domain.ValueObjects;

    public class Debit : MyBasic.Domain.Accounts.Debit
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
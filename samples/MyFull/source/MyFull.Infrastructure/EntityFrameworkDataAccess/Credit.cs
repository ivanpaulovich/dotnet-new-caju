namespace MyFull.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using MyFull.Domain.Accounts;
    using MyFull.Domain.ValueObjects;

    public class Credit : MyFull.Domain.Accounts.Credit
    {
        public Guid AccountId { get; protected set; }

        protected Credit() { }

        public Credit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToDeposit;
            this.TransactionDate = transactionDate;
        }
    }
}
namespace MyBasic.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using MyBasic.Domain.Accounts;
    using MyBasic.Domain.ValueObjects;

    public class Credit : MyBasic.Domain.Accounts.Credit
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
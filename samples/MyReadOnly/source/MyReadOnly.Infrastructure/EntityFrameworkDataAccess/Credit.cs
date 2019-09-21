namespace MyReadOnly.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using MyReadOnly.Domain.Accounts;
    using MyReadOnly.Domain.ValueObjects;

    public class Credit : MyReadOnly.Domain.Accounts.Credit
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
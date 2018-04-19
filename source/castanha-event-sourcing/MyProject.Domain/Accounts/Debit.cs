namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System;

    public class Debit : Transaction
    {
        protected Debit()
        {

        }

        public Debit(Guid accountId, Amount amount)
            : base(accountId, amount)
        {
        }

        public Debit(Guid transactionId, Guid accountId, Amount amount, DateTime transactionDate)
            : base(accountId, amount, transactionDate)
        {
            Id = transactionId;
        }

        public override string Description
        {
            get
            {
                return "Debit";
            }
        }
    }
}

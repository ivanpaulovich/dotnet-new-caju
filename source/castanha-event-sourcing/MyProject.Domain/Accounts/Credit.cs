namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System;

    public class Credit : Transaction
    {
        protected Credit()
        {

        }

        public Credit(Guid accountId, Amount amount)
            : base(accountId, amount)
        {
        }

        public Credit(Guid transactionId, Guid accountId, Amount amount, DateTime transactionDate)
            : base(accountId, amount, transactionDate)
        {
            Id = transactionId;
        }

        public override string Description
        {
            get
            {
                return "Credit";
            }
        }
    }
}

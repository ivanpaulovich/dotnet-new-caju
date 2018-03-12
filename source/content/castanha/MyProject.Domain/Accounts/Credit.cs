namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;

    public class Credit : Transaction
    {
        public Credit(Amount amount)
            : base(amount)
        {
        }

        public Credit(System.Guid transactionId, Amount amount, System.DateTime transactionDate)
            : base(amount, transactionDate)
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

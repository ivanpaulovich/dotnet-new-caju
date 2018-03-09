namespace MyFullProject.Domain.Accounts
{
    using MyFullProject.Domain.ValueObjects;

    public class Debit : Transaction
    {
        public Debit()
        {

        }

        public Debit(Amount amount)
            :base(amount)
        {

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

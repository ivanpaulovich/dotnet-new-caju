namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;

    public class Debit : Transaction
    {
        protected Debit()
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

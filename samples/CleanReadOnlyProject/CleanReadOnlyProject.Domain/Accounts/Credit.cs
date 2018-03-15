namespace CleanReadOnlyProject.Domain.Accounts
{
    using CleanReadOnlyProject.Domain.ValueObjects;

    public class Credit : Transaction
    {
        public Credit()
        {

        }

        public Credit(Amount amount)
            : base(amount)
        {

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

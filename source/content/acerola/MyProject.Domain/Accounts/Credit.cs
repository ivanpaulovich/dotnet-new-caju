namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;

    public class Credit : Transaction
    {
        protected Credit()
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

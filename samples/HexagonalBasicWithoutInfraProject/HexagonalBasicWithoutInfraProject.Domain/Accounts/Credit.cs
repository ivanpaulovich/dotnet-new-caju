namespace HexagonalBasicWithoutInfraProject.Domain.Accounts
{
    using HexagonalBasicWithoutInfraProject.Domain.ValueObjects;

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

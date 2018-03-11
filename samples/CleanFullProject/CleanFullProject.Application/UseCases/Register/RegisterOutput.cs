namespace CleanFullProject.Application.UseCases.Register
{
    using CleanFullProject.Application.Outputs;
    public class RegisterOutput
    {
        public CustomerOutput Customer { get; private set; }
        public AccountOutput Account { get; private set; }

        public RegisterOutput()
        {

        }

        public RegisterOutput(CustomerOutput customer, AccountOutput account)
        {
            Customer = customer;
            Account = account;
        }
    }
}

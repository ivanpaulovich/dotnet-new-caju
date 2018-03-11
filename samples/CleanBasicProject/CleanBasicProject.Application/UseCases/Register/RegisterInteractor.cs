namespace CleanBasicProject.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using CleanBasicProject.Domain.Customers;
    using CleanBasicProject.Domain.ValueObjects;
    using CleanBasicProject.Application.Repositories;
    using CleanBasicProject.Domain.Accounts;
    using CleanBasicProject.Application.Outputs;

    public class RegisterInteractor : IInputBoundary<RegisterInput>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<RegisterOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;
        
        public RegisterInteractor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<RegisterOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public async Task Process(RegisterInput input)
        {
            Customer customer = new Customer(
                new PIN(input.PIN),
                new Name(input.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(input.InitialAmount));
            account.Deposit(credit);

            customer.Register(account.Id);

            await customerWriteOnlyRepository.Add(customer);
            await accountWriteOnlyRepository.Add(account);

            CustomerOutput customerOutput = outputConverter.Map<CustomerOutput>(customer);
            AccountOutput accountOutput = outputConverter.Map<AccountOutput>(account);
            RegisterOutput output = new RegisterOutput(customerOutput, accountOutput);

            outputBoundary.Populate(output);
        }
    }
}

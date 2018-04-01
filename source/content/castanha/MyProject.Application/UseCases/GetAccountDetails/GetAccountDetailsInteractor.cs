namespace MyProject.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using MyProject.Application.Outputs;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<AccountOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;

        public GetAccountDetailsInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<AccountOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.outputConverter = responseConverter;
        }

        public async Task Process(GetAccountDetailsInput input)
        {
            Account account = await accountReadOnlyRepository.Get(input.AccountId);
			if (account == null)
                throw new AccountNotFoundException($"The account {input.AccountId} does not exists or is already closed.");

            AccountOutput output = outputConverter.Map<AccountOutput>(account);
            outputBoundary.Populate(output);
        }
    }
}

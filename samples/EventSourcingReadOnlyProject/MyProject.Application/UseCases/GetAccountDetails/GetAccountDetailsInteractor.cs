namespace EventSourcingReadOnlyProject.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using EventSourcingReadOnlyProject.Application.Outputs;
    using EventSourcingReadOnlyProject.Application.Repositories;

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

        public async Task Process(GetAccountDetailsInput message)
        {
            var account = await accountReadOnlyRepository.Get(message.AccountId);
            if (account == null)
            {
                outputBoundary.Populate(null);
                return;
            }

            AccountOutput output = outputConverter.Map<AccountOutput>(account);
            outputBoundary.Populate(output);
        }
    }
}

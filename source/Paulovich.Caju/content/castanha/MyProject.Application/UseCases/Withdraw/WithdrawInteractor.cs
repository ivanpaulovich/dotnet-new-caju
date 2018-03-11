namespace MyProject.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using MyProject.Application.Outputs;
    using MyProject.Domain.ValueObjects;
    using MyProject.Application.ServiceBus;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;

    public class WithdrawInteractor : IInputBoundary<WithdrawInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IPublisher bus;
        private readonly IOutputBoundary<WithdrawOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;
        
        public WithdrawInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<WithdrawOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(WithdrawInput command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(command.Amount));
            account.Withdraw(debit);

            var domainEvents = account.GetEvents();
            await bus.Publish(domainEvents);

            TransactionOutput transactionOutput = responseConverter.Map<TransactionOutput>(debit);
            WithdrawOutput output = new WithdrawOutput(transactionOutput, account.GetCurrentBalance().Value);

            outputBoundary.Populate(output);
        }
    }
}

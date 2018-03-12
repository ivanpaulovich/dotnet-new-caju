namespace MyProject.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using MyProject.Application.ServiceBus;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;

    public class CloseInteractor : IInputBoundary<CloseInput>
    {
        private readonly IPublisher bus;
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<CloseOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;

        public CloseInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<CloseOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.bus = bus;
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(CloseInput request)
        {
            Account account = await accountReadOnlyRepository.Get(request.AccountId);
            account.Close();

            var domainEvents = account.GetEvents();
            await bus.Publish(domainEvents);

            CloseOutput response = responseConverter.Map<CloseOutput>(account);
            this.outputBoundary.Populate(response);
        }
    }
}
namespace EventSourcingReadOnlyProject.Application.EventHandlers
{
    using EventSourcingReadOnlyProject.Application.Repositories;
    using EventSourcingReadOnlyProject.Domain.Accounts;
    using EventSourcingReadOnlyProject.Domain.Accounts.Events;

    public class OpenedEventHandler : IEventHandler<OpenedDomainEvent>
    {
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public OpenedEventHandler(
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(OpenedDomainEvent domainEvent)
        {
            Account account = new Account();
            account.Apply(domainEvent);
            accountWriteOnlyRepository.Add(account).Wait();
        }
    }
}

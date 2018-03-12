namespace EventSourcingBasicProject.Application.EventHandlers
{
    using EventSourcingBasicProject.Application.Repositories;
    using EventSourcingBasicProject.Domain.Accounts;
    using EventSourcingBasicProject.Domain.Accounts.Events;

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

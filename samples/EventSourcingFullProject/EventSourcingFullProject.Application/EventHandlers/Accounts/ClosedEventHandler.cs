namespace EventSourcingFullProject.Application.EventHandlers
{
    using EventSourcingFullProject.Application.Repositories;
    using EventSourcingFullProject.Domain.Accounts;
    using EventSourcingFullProject.Domain.Accounts.Events;

    public class ClosedEventHandler : IEventHandler<ClosedDomainEvent>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public ClosedEventHandler(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(ClosedDomainEvent domainEvent)
        {
            Account account = accountReadOnlyRepository.Get(domainEvent.AggregateRootId).Result;

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            accountWriteOnlyRepository.Delete(account).Wait();
        }
    }
}

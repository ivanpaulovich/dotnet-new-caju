namespace EventSourcingBasicProject.Application.EventHandlers
{
    using EventSourcingBasicProject.Application.Repositories;
    using EventSourcingBasicProject.Domain.Accounts;
    using EventSourcingBasicProject.Domain.Accounts.Events;

    public class DepositedEventHandler : IEventHandler<DepositedDomainEvent>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public DepositedEventHandler(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(DepositedDomainEvent domainEvent)
        {
            Account account = accountReadOnlyRepository.Get(domainEvent.AggregateRootId).Result;

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);
            accountWriteOnlyRepository.Update(account).Wait();
        }
    }
}

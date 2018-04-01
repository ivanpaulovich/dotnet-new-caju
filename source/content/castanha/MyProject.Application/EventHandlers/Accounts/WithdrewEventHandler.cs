namespace MyProject.Application.EventHandlers
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using MyProject.Domain.Accounts.Events;

    public class WithdrewEventHandler : IEventHandler<WithdrewDomainEvent>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public WithdrewEventHandler(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(WithdrewDomainEvent domainEvent)
        {
            Account account = accountReadOnlyRepository.Get(domainEvent.AggregateRootId).Result;

            if (account == null)
                throw new AccountNotFoundException($"The account {domainEvent.AggregateRootId} does not exists or is already closed.");

            if (account.Version != domainEvent.Version)
                throw new TransactionConflictException(account, domainEvent);

            account.Apply(domainEvent);
            accountWriteOnlyRepository.Update(domainEvent).Wait();
        }
    }
}

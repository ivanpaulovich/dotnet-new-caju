namespace MyProject.Application.EventHandlers
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts.Events;

    public class DepositedEventHandler : IEventHandler<DepositedDomainEvent>
    {
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public DepositedEventHandler(
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(DepositedDomainEvent domainEvent)
        {
            accountWriteOnlyRepository.Update(domainEvent).Wait();
        }
    }
}
namespace MyProject.Application.EventHandlers
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts.Events;

    public class WithdrewEventHandler : IEventHandler<WithdrewDomainEvent>
    {
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public WithdrewEventHandler(
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(WithdrewDomainEvent domainEvent)
        {
            accountWriteOnlyRepository.Update(domainEvent).Wait();
        }
    }
}
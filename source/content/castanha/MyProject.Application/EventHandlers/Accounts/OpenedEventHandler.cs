namespace MyProject.Application.EventHandlers
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts.Events;

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
            accountWriteOnlyRepository.Add(domainEvent).Wait();
        }
    }
}

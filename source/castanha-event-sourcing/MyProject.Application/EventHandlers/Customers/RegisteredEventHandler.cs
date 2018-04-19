namespace MyProject.Application.EventHandlers
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers.Events;

    public class RegisteredEventHandler : IEventHandler<RegisteredDomainEvent>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public RegisteredEventHandler(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public void Handle(RegisteredDomainEvent domainEvent)
        {
            customerWriteOnlyRepository.Add(domainEvent).Wait();
        }
    }
}

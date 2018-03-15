namespace EventSourcingFullProject.Application.EventHandlers
{
    using EventSourcingFullProject.Application.Repositories;
    using EventSourcingFullProject.Domain.Customers;
    using EventSourcingFullProject.Domain.Customers.Events;

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
            Customer customer = new Customer();
            customer.Apply(domainEvent);
            customerWriteOnlyRepository.Add(customer).Wait();
        }
    }
}

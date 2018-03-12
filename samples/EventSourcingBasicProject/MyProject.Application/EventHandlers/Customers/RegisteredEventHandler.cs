namespace EventSourcingBasicProject.Application.EventHandlers
{
    using EventSourcingBasicProject.Application.Repositories;
    using EventSourcingBasicProject.Domain.Customers;
    using EventSourcingBasicProject.Domain.Customers.Events;

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

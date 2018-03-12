namespace EventSourcingFullProject.Application.ServiceBus
{
    using EventSourcingFullProject.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPublisher
    {
        Task Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}

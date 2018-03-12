namespace EventSourcingEmptyProject.Application.ServiceBus
{
    using EventSourcingEmptyProject.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPublisher
    {
        Task Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}

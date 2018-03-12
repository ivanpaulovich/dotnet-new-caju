namespace EventSourcingBasicProject.Application.ServiceBus
{
    using EventSourcingBasicProject.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPublisher
    {
        Task Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}

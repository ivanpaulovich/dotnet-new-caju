namespace MyProject.Application.ServiceBus
{
    using MyProject.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPublisher
    {
        Task Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}

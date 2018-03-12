namespace EventSourcingEmptyProject.Application
{
    using EventSourcingEmptyProject.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}

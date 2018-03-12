namespace EventSourcingFullProject.Application
{
    using EventSourcingFullProject.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}

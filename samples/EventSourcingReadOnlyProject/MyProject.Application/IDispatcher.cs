namespace EventSourcingReadOnlyProject.Application
{
    using EventSourcingReadOnlyProject.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}

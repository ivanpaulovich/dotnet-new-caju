namespace EventSourcingBasicProject.Application
{
    using EventSourcingBasicProject.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}

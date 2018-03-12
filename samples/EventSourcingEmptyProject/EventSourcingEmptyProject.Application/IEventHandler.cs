namespace EventSourcingEmptyProject.Application
{
    public interface IEventHandler<in T>
    {
        void Handle(T domainEvent);
    }
}

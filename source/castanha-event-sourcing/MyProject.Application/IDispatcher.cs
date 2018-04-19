namespace MyProject.Application
{
    using MyProject.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}

namespace EventSourcingBasicProject.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}
namespace EventSourcingEmptyProject.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}
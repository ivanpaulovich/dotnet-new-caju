namespace EventSourcingReadOnlyProject.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}
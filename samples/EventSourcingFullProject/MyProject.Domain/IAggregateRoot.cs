namespace EventSourcingFullProject.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}
namespace MyProject.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}
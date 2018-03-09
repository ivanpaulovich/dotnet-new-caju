namespace Empty.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
namespace Basic.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
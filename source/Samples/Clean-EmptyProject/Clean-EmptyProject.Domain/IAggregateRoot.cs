namespace Clean_EmptyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
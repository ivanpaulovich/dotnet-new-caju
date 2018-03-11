namespace CleanReadOnlyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
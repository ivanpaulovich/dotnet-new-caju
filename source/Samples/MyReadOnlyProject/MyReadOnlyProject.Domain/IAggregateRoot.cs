namespace MyReadOnlyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
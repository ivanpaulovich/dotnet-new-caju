namespace Hexagonal_EmptyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
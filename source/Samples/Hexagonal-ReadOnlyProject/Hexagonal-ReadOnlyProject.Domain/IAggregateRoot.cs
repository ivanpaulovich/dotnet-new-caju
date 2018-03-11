namespace Hexagonal_ReadOnlyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
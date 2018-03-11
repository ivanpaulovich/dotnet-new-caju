namespace Hexagonal_FullProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
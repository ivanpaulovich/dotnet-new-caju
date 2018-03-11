namespace Hexagonal_BasicProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
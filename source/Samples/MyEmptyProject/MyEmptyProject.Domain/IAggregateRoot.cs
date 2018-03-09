namespace MyEmptyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
namespace MyFullProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
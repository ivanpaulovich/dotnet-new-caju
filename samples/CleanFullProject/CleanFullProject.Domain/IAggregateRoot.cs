namespace CleanFullProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
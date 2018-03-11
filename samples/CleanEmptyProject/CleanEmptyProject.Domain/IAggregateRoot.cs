namespace CleanEmptyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
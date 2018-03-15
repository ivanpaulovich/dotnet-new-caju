namespace CleanBasicMongoProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
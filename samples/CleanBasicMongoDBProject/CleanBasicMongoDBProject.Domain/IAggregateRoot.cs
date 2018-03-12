namespace CleanBasicMongoDBProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
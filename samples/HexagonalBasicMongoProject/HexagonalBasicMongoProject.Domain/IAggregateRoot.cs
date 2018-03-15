namespace HexagonalBasicMongoProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
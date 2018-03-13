namespace HexagonalBasicWithoutInfraProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
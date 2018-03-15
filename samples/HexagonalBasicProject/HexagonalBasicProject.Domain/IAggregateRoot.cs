namespace HexagonalBasicProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
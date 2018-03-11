namespace HexagonalEmptyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
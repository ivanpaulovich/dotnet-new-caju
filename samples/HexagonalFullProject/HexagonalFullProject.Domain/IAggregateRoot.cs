namespace HexagonalFullProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
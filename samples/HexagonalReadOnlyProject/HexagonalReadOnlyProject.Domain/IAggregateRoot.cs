namespace HexagonalReadOnlyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
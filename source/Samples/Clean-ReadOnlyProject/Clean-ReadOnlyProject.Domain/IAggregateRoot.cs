namespace Clean_ReadOnlyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
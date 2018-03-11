namespace Clean_BasicProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
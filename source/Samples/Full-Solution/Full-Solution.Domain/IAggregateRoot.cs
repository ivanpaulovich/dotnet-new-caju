namespace Full_Solution.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
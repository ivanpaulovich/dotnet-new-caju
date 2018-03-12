namespace CleanBasicWithoutInfraProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}
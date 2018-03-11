namespace Clean_ReadOnlyProject.Domain
{
    using System;

    //
    // Events should be associated with only one AggregateRootId
    // Events should be serializable
    // The version field is used for optimistic transaction control
    //

    public interface IDomainEvent
    {
        Guid AggregateRootId { get; }
        int Version { get; }
    }
}

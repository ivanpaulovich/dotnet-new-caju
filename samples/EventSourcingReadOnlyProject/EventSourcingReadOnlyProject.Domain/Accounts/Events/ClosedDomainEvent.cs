namespace EventSourcingReadOnlyProject.Domain.Accounts.Events
{
    using System;

    /// <summary>
    /// Events should be immutable and serializable
    /// </summary>
    public class ClosedDomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }

        public ClosedDomainEvent(
            Guid aggregateRootId,
            int version)
        {
            AggregateRootId = aggregateRootId;
            Version = version;
        }
    }
}

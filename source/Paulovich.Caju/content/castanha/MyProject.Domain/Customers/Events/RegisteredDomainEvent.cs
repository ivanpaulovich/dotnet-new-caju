namespace MyProject.Domain.Customers.Events
{
    using MyProject.Domain.ValueObjects;
    using System;

    /// <summary>
    /// Events should be immutable and serializable
    /// </summary>
    public class RegisteredDomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }
        public Name CustomerName { get; private set; }
        public PIN CustomerPIN { get; private set; }
        public Guid AccountId { get; private set; }

        public RegisteredDomainEvent(
            Guid aggregateRootId, 
            int version,
            Name customerName,
            PIN customerPIN, 
            Guid accountId)
        {
            AggregateRootId = aggregateRootId;
            Version = version;
            CustomerName = customerName;
            CustomerPIN = customerPIN;
            AccountId = accountId;
        }
    }
}

namespace EventSourcingReadOnlyProject.Domain.Accounts.Events
{
    using EventSourcingReadOnlyProject.Domain.ValueObjects;
    using System;

    /// <summary>
    /// Events should be immutable and serializable
    /// </summary>
    public class DepositedDomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }
        public Guid TransactionId { get; private set; }
        public Amount TransactionAmount { get; private set; }

        public DepositedDomainEvent(
            Guid aggregateRootId, 
            int version, 
            Guid transactionId, 
            Amount transactionAmount)
        {
            AggregateRootId = aggregateRootId;
            Version = version;
            TransactionId = transactionId;
            TransactionAmount = transactionAmount;
        }
    }
}

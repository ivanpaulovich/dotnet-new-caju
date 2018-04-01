namespace MyProject.Domain.Accounts.Events
{
    using MyProject.Domain.ValueObjects;
    using System;

    /// <summary>
    /// Events should be immutable and serializable
    /// </summary>
    public class WithdrewDomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }
        public Guid TransactionId { get; private set; }
        public Amount TransactionAmount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public WithdrewDomainEvent(
            Guid aggregateRootId, 
            int version,
            Guid transactionId, 
            Amount transactionAmount,
            DateTime transactionDate)
        {
            AggregateRootId = aggregateRootId;
            Version = version;
            TransactionId = transactionId;
            TransactionAmount = transactionAmount;
            TransactionDate = transactionDate;
        }
    }
}

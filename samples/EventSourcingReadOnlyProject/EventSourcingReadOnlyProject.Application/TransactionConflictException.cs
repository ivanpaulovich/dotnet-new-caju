using EventSourcingReadOnlyProject.Domain;

namespace EventSourcingReadOnlyProject.Application
{
    public class TransactionConflictException : EventSourcingReadOnlyProjectException
    {
        public IAggregateRoot AggregateRoot { get; private set; }
        public IDomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(IAggregateRoot aggregateRoot, IDomainEvent domainEvent)
        {
            this.AggregateRoot = aggregateRoot;
            this.DomainEvent = domainEvent;
        }
    }
}

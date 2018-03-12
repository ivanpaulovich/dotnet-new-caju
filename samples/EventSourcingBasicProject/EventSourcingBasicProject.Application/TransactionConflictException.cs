using EventSourcingBasicProject.Domain;

namespace EventSourcingBasicProject.Application
{
    public class TransactionConflictException : EventSourcingBasicProjectException
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

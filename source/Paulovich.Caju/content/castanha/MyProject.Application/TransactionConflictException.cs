using MyProject.Domain;

namespace MyProject.Application
{
    public class TransactionConflictException : MyProjectException
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

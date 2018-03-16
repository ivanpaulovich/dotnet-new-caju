using MyProject.Domain;
using System;

namespace MyProject.Application
{
    public class TransactionConflictException : Exception
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

namespace MyProject.Domain
{
    using System;
    using System.Collections.Generic;

    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly Dictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();
        
        public virtual int Version { get; protected set; }

        public AggregateRoot()
        {
            Version = 0;
        }

        protected void Register<T>(Action<T> when)
        {
            handlers.Add(typeof(T), e => when((T)e));
        }

        protected void Raise(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
            handlers[domainEvent.GetType()](domainEvent);
            Version++;
        }

        public IReadOnlyCollection<IDomainEvent> GetEvents()
        {
            return domainEvents;
        }

        public void Apply(IDomainEvent domainEvent)
        {
            handlers[domainEvent.GetType()](domainEvent);
            Version++;
        }
    }
}

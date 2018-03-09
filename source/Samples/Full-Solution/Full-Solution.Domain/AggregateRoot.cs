namespace Full_Solution.Domain
{
    using System;
    using System.Collections.Generic;

    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly Dictionary<Type, Action<object>> handlers = new Dictionary<Type, Action<object>>();
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();
        private int version = 0;
        public int Version
        { 
            get
            {
                return version;
            } 
            protected set
            {
                version = value;
            }
        }

        protected void Register<T>(Action<T> when)
        {
            handlers.Add(typeof(T), e => when((T)e));
        }

        protected void Raise(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
            Action<object> eventHandler = handlers[domainEvent.GetType()];
            eventHandler(domainEvent);
            Version++;
        }

        public IReadOnlyCollection<IDomainEvent> GetEvents()
        {
            return domainEvents;
        }

        public void Apply(IDomainEvent domainEvent)
        {
            Action<object> eventHandler = handlers[domainEvent.GetType()];
            eventHandler(domainEvent);
            Version++;
        }
    }
}

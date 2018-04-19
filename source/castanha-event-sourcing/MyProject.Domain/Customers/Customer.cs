namespace MyProject.Domain.Customers
{
    using System;
    using MyProject.Domain.ValueObjects;
    using MyProject.Domain.Customers.Events;

    public class Customer : AggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual PIN PIN { get; protected set; }
        public virtual AccountCollection Accounts { get; protected set; }

        public Customer()
        {
            Register<RegisteredDomainEvent>(When);
        }

        public Customer(PIN pin, Name name)
            : this()
        {
            PIN = pin;
            Name = name;
        }

        public virtual void Register(Guid accountId)
        {
            var domainEvent = new RegisteredDomainEvent(
                Id, Version, Name, PIN,
                accountId);

            Raise(domainEvent); 
        }

        protected void When(RegisteredDomainEvent domainEvent)
        {
            Id = domainEvent.AggregateRootId;
            Version = domainEvent.Version;
            Name = domainEvent.CustomerName;
            PIN = domainEvent.CustomerPIN;

            Accounts = new AccountCollection();
            Accounts.Add(domainEvent.AccountId);
        }
    }
}

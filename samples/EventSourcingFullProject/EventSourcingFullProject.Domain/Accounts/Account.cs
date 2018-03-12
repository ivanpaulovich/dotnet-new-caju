namespace EventSourcingFullProject.Domain.Accounts
{
    using System;
    using EventSourcingFullProject.Domain.Accounts.Events;
    using EventSourcingFullProject.Domain.Customers.Events;
    using EventSourcingFullProject.Domain.ValueObjects;

    public class Account : AggregateRoot
    {
        public TransactionCollection Transactions { get; private set; }

        public Account()
        {
            Register<DepositedDomainEvent>(When);
            Register<WithdrewDomainEvent>(When);
            Register<OpenedDomainEvent>(When);
            Register<ClosedDomainEvent>(When);

            Transactions = new TransactionCollection();
        }

        public void Open(Credit credit)
        {
            var domainEvent = new OpenedDomainEvent(
                    Id,
                    Version,
                    credit.Id,
                    credit.Amount,
                    credit.TransactionDate
                );

            Raise(domainEvent);
        }

        public void Deposit(Credit credit)
        {
            var domainEvent = new DepositedDomainEvent(
                    Id,
                    Version,
                    credit.Id,
                    credit.Amount
                );

            Raise(domainEvent);
        }

        public void Withdraw(Debit debit)
        {
            if (Transactions.GetCurrentBalance() < debit.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {debit.Amount}.");

            var domainEvent = new WithdrewDomainEvent(
                    Id,
                    Version,
                    debit.Id,
                    debit.Amount
                );

            Raise(domainEvent);
        }

        public void Close()
        {
            if (Transactions.GetCurrentBalance() > new Amount(0))
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");

            var domainEvent = new ClosedDomainEvent(
                    Id,
                    Version
                );

            Raise(domainEvent);
        }

        protected void When(OpenedDomainEvent domainEvent)
        {
            //
            // Open an Account
            //

            Id = domainEvent.AggregateRootId;
            Transactions = new TransactionCollection();

            Transaction credit = new Credit(
                domainEvent.TransactionId,
                domainEvent.TransactionAmount,
                domainEvent.TransactionDate);

            Transactions.Add(credit);
        }

        public Amount GetCurrentBalance()
        {
            return Transactions.GetCurrentBalance();
        }

        protected void When(DepositedDomainEvent domainEvent)
        {
            Transaction credit = new Credit(domainEvent.TransactionAmount);
            Transactions.Add(credit);
        }

        protected void When(WithdrewDomainEvent domainEvent)
        {
            Transaction debit = new Debit(domainEvent.TransactionAmount);
            Transactions.Add(debit);
        }

        protected void When(ClosedDomainEvent domainEvent)
        {

        }
    }
}

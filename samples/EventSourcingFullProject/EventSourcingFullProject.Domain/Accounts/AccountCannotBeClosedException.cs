namespace EventSourcingFullProject.Domain.Accounts
{
    public class AccountCannotBeClosedException : DomainException
    {
        internal AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}

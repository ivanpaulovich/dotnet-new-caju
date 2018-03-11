namespace CleanBasicProject.Domain.Accounts
{
    public class AccountCannotBeClosedException : DomainException
    {
        internal AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}

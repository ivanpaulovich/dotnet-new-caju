namespace Clean_BasicProject.Domain.Accounts
{
    public class AccountCannotBeClosedException : DomainException
    {
        internal AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}

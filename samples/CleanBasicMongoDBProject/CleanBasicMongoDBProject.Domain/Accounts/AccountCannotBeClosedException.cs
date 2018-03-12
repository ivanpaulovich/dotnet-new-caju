namespace CleanBasicMongoDBProject.Domain.Accounts
{
    public class AccountCannotBeClosedException : DomainException
    {
        internal AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}

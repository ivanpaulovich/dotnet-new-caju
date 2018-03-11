namespace Hexagonal_ReadOnlyProject.Domain.Accounts
{
    public class InsuficientFundsException : DomainException
    {
        internal InsuficientFundsException(string message)
            : base(message)
        { }
    }
}

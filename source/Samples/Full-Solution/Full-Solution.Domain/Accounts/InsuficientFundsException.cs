namespace Full_Solution.Domain.Accounts
{
    public class InsuficientFundsException : DomainException
    {
        internal InsuficientFundsException(string message)
            : base(message)
        { }
    }
}

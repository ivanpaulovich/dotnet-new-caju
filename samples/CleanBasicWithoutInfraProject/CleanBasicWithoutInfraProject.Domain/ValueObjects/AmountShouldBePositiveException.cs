namespace CleanBasicWithoutInfraProject.Domain.ValueObjects
{
    public class AmountShouldBePositiveException : DomainException
    {
        internal AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}

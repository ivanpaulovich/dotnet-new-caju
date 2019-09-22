namespace MyFull.Application.Exceptions
{
    using MyFull.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}
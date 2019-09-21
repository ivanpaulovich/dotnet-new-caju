namespace MyBasic.Application.Exceptions
{
    using MyBasic.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}
namespace MyReadOnly.Application.Exceptions
{
    using MyReadOnly.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}
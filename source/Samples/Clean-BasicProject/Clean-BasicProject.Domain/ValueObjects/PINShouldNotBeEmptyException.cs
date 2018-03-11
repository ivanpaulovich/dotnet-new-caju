namespace Clean_BasicProject.Domain.ValueObjects
{
    public class PINShouldNotBeEmptyException : DomainException
    {
        internal PINShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}

namespace Hexagonal_BasicProject.Domain
{
    public class DomainException : Hexagonal_BasicProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

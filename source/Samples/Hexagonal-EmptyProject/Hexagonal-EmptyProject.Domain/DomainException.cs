namespace Hexagonal_EmptyProject.Domain
{
    public class DomainException : Hexagonal_EmptyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

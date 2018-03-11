namespace Hexagonal_FullProject.Domain
{
    public class DomainException : Hexagonal_FullProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

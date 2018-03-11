namespace Hexagonal_ReadOnlyProject.Domain
{
    public class DomainException : Hexagonal_ReadOnlyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

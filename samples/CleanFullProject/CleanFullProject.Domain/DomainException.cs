namespace CleanFullProject.Domain
{
    public class DomainException : CleanFullProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

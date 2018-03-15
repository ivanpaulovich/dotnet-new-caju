namespace CleanReadOnlyProject.Domain
{
    public class DomainException : CleanReadOnlyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

namespace CleanEmptyProject.Domain
{
    public class DomainException : CleanEmptyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

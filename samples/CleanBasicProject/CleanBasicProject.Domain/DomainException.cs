namespace CleanBasicProject.Domain
{
    public class DomainException : CleanBasicProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

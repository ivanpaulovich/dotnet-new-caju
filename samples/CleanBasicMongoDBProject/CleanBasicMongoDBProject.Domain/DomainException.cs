namespace CleanBasicMongoDBProject.Domain
{
    public class DomainException : CleanBasicMongoDBProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

namespace CleanBasicMongoProject.Domain
{
    public class DomainException : CleanBasicMongoProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

namespace CleanBasicWithoutInfraProject.Domain
{
    public class DomainException : CleanBasicWithoutInfraProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

namespace Clean_BasicProject.Domain
{
    public class DomainException : Clean_BasicProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

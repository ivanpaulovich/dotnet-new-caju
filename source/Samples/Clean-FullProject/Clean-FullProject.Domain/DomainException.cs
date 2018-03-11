namespace Clean_FullProject.Domain
{
    public class DomainException : Clean_FullProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

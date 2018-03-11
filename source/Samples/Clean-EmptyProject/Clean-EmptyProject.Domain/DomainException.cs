namespace Clean_EmptyProject.Domain
{
    public class DomainException : Clean_EmptyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

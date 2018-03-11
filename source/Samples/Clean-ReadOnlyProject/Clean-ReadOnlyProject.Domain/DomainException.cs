namespace Clean_ReadOnlyProject.Domain
{
    public class DomainException : Clean_ReadOnlyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

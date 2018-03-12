namespace EventSourcingReadOnlyProject.Domain
{
    public class DomainException : EventSourcingReadOnlyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

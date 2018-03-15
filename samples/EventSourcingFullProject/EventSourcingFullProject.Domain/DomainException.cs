namespace EventSourcingFullProject.Domain
{
    public class DomainException : EventSourcingFullProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

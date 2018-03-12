namespace EventSourcingEmptyProject.Domain
{
    public class DomainException : EventSourcingEmptyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

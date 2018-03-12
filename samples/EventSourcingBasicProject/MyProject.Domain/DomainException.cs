namespace EventSourcingBasicProject.Domain
{
    public class DomainException : EventSourcingBasicProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

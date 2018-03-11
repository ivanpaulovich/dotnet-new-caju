namespace HexagonalBasicProject.Domain
{
    public class DomainException : HexagonalBasicProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

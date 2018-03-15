namespace HexagonalFullProject.Domain
{
    public class DomainException : HexagonalFullProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

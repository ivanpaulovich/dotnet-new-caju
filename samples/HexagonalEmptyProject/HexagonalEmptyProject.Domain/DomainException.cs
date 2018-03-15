namespace HexagonalEmptyProject.Domain
{
    public class DomainException : HexagonalEmptyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

namespace HexagonalReadOnlyProject.Domain
{
    public class DomainException : HexagonalReadOnlyProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

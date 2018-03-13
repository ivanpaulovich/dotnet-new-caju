namespace HexagonalBasicMongoProject.Domain
{
    public class DomainException : HexagonalBasicMongoProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

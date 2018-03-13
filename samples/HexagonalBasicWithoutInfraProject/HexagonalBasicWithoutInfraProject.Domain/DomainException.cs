namespace HexagonalBasicWithoutInfraProject.Domain
{
    public class DomainException : HexagonalBasicWithoutInfraProjectException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}

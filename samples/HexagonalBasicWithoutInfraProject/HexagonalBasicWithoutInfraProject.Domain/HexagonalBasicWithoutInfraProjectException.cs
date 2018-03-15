namespace HexagonalBasicWithoutInfraProject.Domain
{
    using System;

    public class HexagonalBasicWithoutInfraProjectException : Exception
    {
        internal HexagonalBasicWithoutInfraProjectException()
        { }

        internal HexagonalBasicWithoutInfraProjectException(string message)
            : base(message)
        { }

        internal HexagonalBasicWithoutInfraProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

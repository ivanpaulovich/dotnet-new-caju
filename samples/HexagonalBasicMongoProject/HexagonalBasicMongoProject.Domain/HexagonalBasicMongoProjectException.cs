namespace HexagonalBasicMongoProject.Domain
{
    using System;

    public class HexagonalBasicMongoProjectException : Exception
    {
        public HexagonalBasicMongoProjectException()
        { }

        public HexagonalBasicMongoProjectException(string message)
            : base(message)
        { }

        public HexagonalBasicMongoProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

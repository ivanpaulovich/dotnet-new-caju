namespace HexagonalBasicProject.Domain
{
    using System;

    public class HexagonalBasicProjectException : Exception
    {
        public HexagonalBasicProjectException()
        { }

        public HexagonalBasicProjectException(string message)
            : base(message)
        { }

        public HexagonalBasicProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

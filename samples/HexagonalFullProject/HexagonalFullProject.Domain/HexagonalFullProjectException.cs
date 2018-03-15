namespace HexagonalFullProject.Domain
{
    using System;

    public class HexagonalFullProjectException : Exception
    {
        public HexagonalFullProjectException()
        { }

        public HexagonalFullProjectException(string message)
            : base(message)
        { }

        public HexagonalFullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

namespace HexagonalReadOnlyProject.Domain
{
    using System;

    public class HexagonalReadOnlyProjectException : Exception
    {
        public HexagonalReadOnlyProjectException()
        { }

        public HexagonalReadOnlyProjectException(string message)
            : base(message)
        { }

        public HexagonalReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

namespace HexagonalEmptyProject.Domain
{
    using System;

    public class HexagonalEmptyProjectException : Exception
    {
        internal HexagonalEmptyProjectException()
        { }

        internal HexagonalEmptyProjectException(string message)
            : base(message)
        { }

        internal HexagonalEmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

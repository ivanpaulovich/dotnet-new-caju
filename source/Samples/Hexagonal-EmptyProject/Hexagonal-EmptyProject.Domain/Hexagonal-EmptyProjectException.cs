namespace Hexagonal_EmptyProject.Domain
{
    using System;

    public class Hexagonal_EmptyProjectException : Exception
    {
        internal Hexagonal_EmptyProjectException()
        { }

        internal Hexagonal_EmptyProjectException(string message)
            : base(message)
        { }

        internal Hexagonal_EmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

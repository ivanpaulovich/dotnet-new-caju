namespace Hexagonal_ReadOnlyProject.Domain
{
    using System;

    public class Hexagonal_ReadOnlyProjectException : Exception
    {
        public Hexagonal_ReadOnlyProjectException()
        { }

        public Hexagonal_ReadOnlyProjectException(string message)
            : base(message)
        { }

        public Hexagonal_ReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

namespace Hexagonal_FullProject.Domain
{
    using System;

    public class Hexagonal_FullProjectException : Exception
    {
        public Hexagonal_FullProjectException()
        { }

        public Hexagonal_FullProjectException(string message)
            : base(message)
        { }

        public Hexagonal_FullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

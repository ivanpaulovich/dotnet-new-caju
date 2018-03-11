namespace Hexagonal_BasicProject.Domain
{
    using System;

    public class Hexagonal_BasicProjectException : Exception
    {
        public Hexagonal_BasicProjectException()
        { }

        public Hexagonal_BasicProjectException(string message)
            : base(message)
        { }

        public Hexagonal_BasicProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

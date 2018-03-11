namespace Clean_BasicProject.Domain
{
    using System;

    public class Clean_BasicProjectException : Exception
    {
        internal Clean_BasicProjectException()
        { }

        internal Clean_BasicProjectException(string message)
            : base(message)
        { }

        internal Clean_BasicProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

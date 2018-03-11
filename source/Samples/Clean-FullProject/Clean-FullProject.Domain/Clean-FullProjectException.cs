namespace Clean_FullProject.Domain
{
    using System;

    public class Clean_FullProjectException : Exception
    {
        internal Clean_FullProjectException()
        { }

        internal Clean_FullProjectException(string message)
            : base(message)
        { }

        internal Clean_FullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

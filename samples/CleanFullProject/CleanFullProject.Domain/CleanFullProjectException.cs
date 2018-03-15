namespace CleanFullProject.Domain
{
    using System;

    public class CleanFullProjectException : Exception
    {
        internal CleanFullProjectException()
        { }

        internal CleanFullProjectException(string message)
            : base(message)
        { }

        internal CleanFullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

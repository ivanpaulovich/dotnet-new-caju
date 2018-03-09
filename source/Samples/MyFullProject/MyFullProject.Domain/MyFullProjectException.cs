namespace MyFullProject.Domain
{
    using System;

    public class MyFullProjectException : Exception
    {
        internal MyFullProjectException()
        { }

        internal MyFullProjectException(string message)
            : base(message)
        { }

        internal MyFullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

namespace MyEmptyProject.Domain
{
    using System;

    public class MyEmptyProjectException : Exception
    {
        internal MyEmptyProjectException()
        { }

        internal MyEmptyProjectException(string message)
            : base(message)
        { }

        internal MyEmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

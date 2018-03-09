namespace MyReadOnlyProject.Domain
{
    using System;

    public class MyReadOnlyProjectException : Exception
    {
        internal MyReadOnlyProjectException()
        { }

        internal MyReadOnlyProjectException(string message)
            : base(message)
        { }

        internal MyReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

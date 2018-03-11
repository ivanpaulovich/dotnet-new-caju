namespace CleanReadOnlyProject.Domain
{
    using System;

    public class CleanReadOnlyProjectException : Exception
    {
        internal CleanReadOnlyProjectException()
        { }

        internal CleanReadOnlyProjectException(string message)
            : base(message)
        { }

        internal CleanReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

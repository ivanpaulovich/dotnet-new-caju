namespace CleanEmptyProject.Domain
{
    using System;

    public class CleanEmptyProjectException : Exception
    {
        internal CleanEmptyProjectException()
        { }

        internal CleanEmptyProjectException(string message)
            : base(message)
        { }

        internal CleanEmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

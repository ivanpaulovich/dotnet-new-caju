namespace CleanBasicProject.Domain
{
    using System;

    public class CleanBasicProjectException : Exception
    {
        internal CleanBasicProjectException()
        { }

        internal CleanBasicProjectException(string message)
            : base(message)
        { }

        internal CleanBasicProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

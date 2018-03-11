namespace Clean_EmptyProject.Domain
{
    using System;

    public class Clean_EmptyProjectException : Exception
    {
        internal Clean_EmptyProjectException()
        { }

        internal Clean_EmptyProjectException(string message)
            : base(message)
        { }

        internal Clean_EmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

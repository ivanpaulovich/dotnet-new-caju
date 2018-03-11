namespace Clean_ReadOnlyProject.Domain
{
    using System;

    public class Clean_ReadOnlyProjectException : Exception
    {
        internal Clean_ReadOnlyProjectException()
        { }

        internal Clean_ReadOnlyProjectException(string message)
            : base(message)
        { }

        internal Clean_ReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

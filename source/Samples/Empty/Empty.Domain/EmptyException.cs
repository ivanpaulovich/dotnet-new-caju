namespace Empty.Domain
{
    using System;

    public class EmptyException : Exception
    {
        internal EmptyException()
        { }

        internal EmptyException(string message)
            : base(message)
        { }

        internal EmptyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

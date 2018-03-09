namespace Basic.Domain
{
    using System;

    public class BasicException : Exception
    {
        internal BasicException()
        { }

        internal BasicException(string message)
            : base(message)
        { }

        internal BasicException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

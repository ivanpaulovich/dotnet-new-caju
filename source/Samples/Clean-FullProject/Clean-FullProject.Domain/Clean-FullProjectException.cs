namespace Clean_FullProject.Domain
{
    using System;

    public class Clean_FullProjectException : Exception
    {
        public Clean_FullProjectException()
        { }

        public Clean_FullProjectException(string message)
            : base(message)
        { }

        public Clean_FullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

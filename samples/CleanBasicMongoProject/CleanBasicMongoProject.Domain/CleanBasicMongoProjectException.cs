namespace CleanBasicMongoProject.Domain
{
    using System;

    public class CleanBasicMongoProjectException : Exception
    {
        internal CleanBasicMongoProjectException()
        { }

        internal CleanBasicMongoProjectException(string message)
            : base(message)
        { }

        internal CleanBasicMongoProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

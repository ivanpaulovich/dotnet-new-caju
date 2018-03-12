namespace CleanBasicMongoDBProject.Domain
{
    using System;

    public class CleanBasicMongoDBProjectException : Exception
    {
        internal CleanBasicMongoDBProjectException()
        { }

        internal CleanBasicMongoDBProjectException(string message)
            : base(message)
        { }

        internal CleanBasicMongoDBProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

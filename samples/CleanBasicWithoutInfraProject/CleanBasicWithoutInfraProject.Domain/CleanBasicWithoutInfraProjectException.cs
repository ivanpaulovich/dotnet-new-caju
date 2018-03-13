namespace CleanBasicWithoutInfraProject.Domain
{
    using System;

    public class CleanBasicWithoutInfraProjectException : Exception
    {
        public CleanBasicWithoutInfraProjectException()
        { }

        public CleanBasicWithoutInfraProjectException(string message)
            : base(message)
        { }

        public CleanBasicWithoutInfraProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

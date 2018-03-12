namespace CleanBasicWithoutInfraProject.Domain
{
    using System;

    public class CleanBasicWithoutInfraProjectException : Exception
    {
        internal CleanBasicWithoutInfraProjectException()
        { }

        internal CleanBasicWithoutInfraProjectException(string message)
            : base(message)
        { }

        internal CleanBasicWithoutInfraProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

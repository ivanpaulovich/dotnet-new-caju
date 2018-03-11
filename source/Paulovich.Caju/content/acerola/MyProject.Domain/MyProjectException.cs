namespace MyProject.Domain
{
    using System;

    public class MyProjectException : Exception
    {
        public MyProjectException()
        { }

        public MyProjectException(string message)
            : base(message)
        { }

        public MyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

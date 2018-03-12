namespace EventSourcingBasicProject.Domain
{
    using System;

    public class EventSourcingBasicProjectException : Exception
    {
        public EventSourcingBasicProjectException()
        { }

        internal EventSourcingBasicProjectException(string message)
            : base(message)
        { }

        internal EventSourcingBasicProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

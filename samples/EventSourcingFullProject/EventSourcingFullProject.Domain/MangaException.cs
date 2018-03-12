namespace EventSourcingFullProject.Domain
{
    using System;

    public class EventSourcingFullProjectException : Exception
    {
        public EventSourcingFullProjectException()
        { }

        internal EventSourcingFullProjectException(string message)
            : base(message)
        { }

        internal EventSourcingFullProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

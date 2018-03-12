namespace EventSourcingEmptyProject.Domain
{
    using System;

    public class EventSourcingEmptyProjectException : Exception
    {
        public EventSourcingEmptyProjectException()
        { }

        internal EventSourcingEmptyProjectException(string message)
            : base(message)
        { }

        internal EventSourcingEmptyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

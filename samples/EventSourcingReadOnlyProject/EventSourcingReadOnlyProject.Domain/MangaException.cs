namespace EventSourcingReadOnlyProject.Domain
{
    using System;

    public class EventSourcingReadOnlyProjectException : Exception
    {
        public EventSourcingReadOnlyProjectException()
        { }

        internal EventSourcingReadOnlyProjectException(string message)
            : base(message)
        { }

        internal EventSourcingReadOnlyProjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

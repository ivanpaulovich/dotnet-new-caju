namespace EventSourcingBasicProject.Infrastructure.Dispatcher
{
    using EventSourcingBasicProject.Application;
    using EventSourcingBasicProject.Domain;
    using System.Collections.Generic;
    using System;
    using EventSourcingBasicProject.Domain.Customers.Events;
    using System.Reflection;
    using EventSourcingBasicProject.Domain.Accounts.Events;

    public class Dispatcher : IDispatcher
    {
        private readonly Dictionary<Type, List<object>> handlers = new Dictionary<Type, List<object>>();

        public Dispatcher(
            IEventHandler<RegisteredDomainEvent> customerRegisteredEventhandler,
            IEventHandler<DepositedDomainEvent> depositedEventhandler,
            IEventHandler<WithdrewDomainEvent> withdrewEventhandler,
            IEventHandler<ClosedDomainEvent> closedEventhandler,
            IEventHandler<OpenedDomainEvent> openedEventhandler)
        {
            Register(customerRegisteredEventhandler);
            Register(depositedEventhandler);
            Register(withdrewEventhandler);
            Register(closedEventhandler);
            Register(openedEventhandler);
        }

        private void Register(object handler)
        {
            Type eventType = ((Type[])((TypeInfo)handler.GetType()).ImplementedInterfaces)[0]
                .GenericTypeArguments[0];

            if (!handlers.ContainsKey(eventType))
                handlers.Add(eventType, new List<object>());

            List<object> handlersList = handlers[eventType];
            handlersList.Add(handler);
        }

        public void Send(IDomainEvent domainEvent)
        {
            //
            // TODO: Catch failures (NotFound, Duplicated Handlers, etc)
            //

            dynamic handlersList = Convert.ChangeType(handlers[domainEvent.GetType()], typeof(List<object>));
            dynamic message = Convert.ChangeType(domainEvent, domainEvent.GetType());

            foreach (var handler in handlersList)
            {
                handler.Handle(message);
            }            
        }
    }
}

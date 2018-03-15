namespace MyProject.Infrastructure.Dispatcher
{
    using MyProject.Application;
    using MyProject.Domain;
#if !Empty
    using MyProject.Domain.Accounts.Events;
    using MyProject.Domain.Customers.Events;
#endif
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Dispatcher : IDispatcher
    {
        private readonly Dictionary<Type, List<object>> handlers = new Dictionary<Type, List<object>>();

        public Dispatcher(
#if Basic
            IEventHandler<RegisteredDomainEvent> customerRegisteredEventhandler,
            IEventHandler<OpenedDomainEvent> openedEventhandler
#endif

#if Full
            IEventHandler<RegisteredDomainEvent> customerRegisteredEventhandler,
            IEventHandler<DepositedDomainEvent> depositedEventhandler,
            IEventHandler<WithdrewDomainEvent> withdrewEventhandler,
            IEventHandler<ClosedDomainEvent> closedEventhandler,
            IEventHandler<OpenedDomainEvent> openedEventhandler
#endif
        )
        {
#if Basic
            Register(customerRegisteredEventhandler);
#endif

#if Full
            Register(customerRegisteredEventhandler);
            Register(depositedEventhandler);
            Register(withdrewEventhandler);
            Register(closedEventhandler);
            Register(openedEventhandler);
#endif
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

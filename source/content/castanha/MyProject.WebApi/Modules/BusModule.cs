namespace MyProject.WebApi.Modules
{
    using Autofac;
    using MyProject.Application.ServiceBus;
#if Kafka
    using MyProject.Infrastructure.ServiceBus;
#endif
    public class BusModule : Autofac.Module
    {
#if Kafka
        public string BrokerList { get; set; }
        public string Topic { get; set; }
#endif
        protected override void Load(ContainerBuilder builder)
        {
#if Kafka
            //
            // Register the Bus
            //
            // IPublisher
            // ISubscriber
            //
            builder.RegisterType<Bus>()
                .As<IPublisher>()
                .As<ISubscriber>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
#endif
        }
    }
}

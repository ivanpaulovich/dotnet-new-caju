namespace MyProject.Infrastructure.ServiceBus
{
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using MyProject.Application.ServiceBus;
    using MyProject.Domain;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using MyProject.Application;

    public class Bus : IPublisher, ISubscriber
    {
        private readonly string brokerList;
        private readonly string topic;
        private readonly Producer<string, string> producer;
        private readonly IDispatcher dispatcher;

        private static Dictionary<string, object> constructConfig(string brokerList, bool enableAutoCommit) =>
            new Dictionary<string, object>
            {
                { "group.id", "myaccountapi-consumer" },
                { "enable.auto.commit", enableAutoCommit },
                { "auto.commit.interval.ms", 5000 },
                { "statistics.interval.ms", 60000 },
                { "bootstrap.servers", brokerList },
                { "default.topic.config", new Dictionary<string, object>()
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };

        public Bus(string brokerList, string topic, IDispatcher dispatcher)
        {
            this.brokerList = brokerList;
            this.topic = topic;
            this.dispatcher = dispatcher;

            producer = new Producer<string, string>(
                new Dictionary<string, object>()
                {{
                    "bootstrap.servers",
                    brokerList
                }},
                new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8));
        }
        
        public async Task Publish(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                string data = JsonConvert.SerializeObject(domainEvent, Formatting.Indented);

                Message<string, string> message = await producer.ProduceAsync(
                    topic, domainEvent.GetType().AssemblyQualifiedName, data);
            }
        }

        public void Listen()
        {
            using (var consumer = new Consumer<string, string>(constructConfig(brokerList, true), new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg)
                    =>
                {
                    Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");

                    try
                    {
                        Type eventType = Type.GetType(msg.Key);
                        IDomainEvent domainEvent = (IDomainEvent)JsonConvert.DeserializeObject(msg.Value, eventType);
                        dispatcher.Send(domainEvent);
                    }
                    catch (DomainException ex)
                    {
                        Console.WriteLine(ex.BusinessMessage);
                    }
                    catch (TransactionConflictException ex)
                    {
                        Console.WriteLine(ex.DomainEvent.ToString());
                    }
                };

                consumer.OnPartitionEOF += (_, end)
                    => Console.WriteLine($"Reached end of topic {end.Topic} partition {end.Partition}, next message will be at offset {end.Offset}");

                consumer.OnError += (_, error)
                    => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                    => Console.WriteLine($"Error consuming from topic/partition/offset {msg.Topic}/{msg.Partition}/{msg.Offset}: {msg.Error}");

                consumer.OnOffsetsCommitted += (_, commit) =>
                {
                    Console.WriteLine($"[{string.Join(", ", commit.Offsets)}]");

                    if (commit.Error)
                    {
                        Console.WriteLine($"Failed to commit offsets: {commit.Error}");
                    }
                    Console.WriteLine($"Successfully committed offsets: [{string.Join(", ", commit.Offsets)}]");
                };

                consumer.OnPartitionsAssigned += (_, partitions) =>
                {
                    Console.WriteLine($"Assigned partitions: [{string.Join(", ", partitions)}], member id: {consumer.MemberId}");
                    consumer.Assign(partitions);
                };

                consumer.OnPartitionsRevoked += (_, partitions) =>
                {
                    Console.WriteLine($"Revoked partitions: [{string.Join(", ", partitions)}]");
                    consumer.Unassign();
                };

                consumer.OnStatistics += (_, json)
                    => Console.WriteLine($"Statistics: {json}");

                consumer.Subscribe(this.topic);

                Console.WriteLine($"Subscribed to: [{string.Join(", ", consumer.Subscription)}]");

                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");
                while (!cancelled)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
        }

        public void Dispose()
        {
            producer.Dispose();
        }
    }
}

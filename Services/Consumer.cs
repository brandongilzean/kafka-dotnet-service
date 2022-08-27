using System;
using System.Collections.Generic;
using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;

namespace kafka_dotnet_service.Services
{
    public class Consumer
    {

        public void Consume()
        {

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test1",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cancellationToken = new CancellationTokenSource();

            var cancelled = false;
            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("input-topic");

                while (!cancelled)
                {
                    var consumeResult = consumer.Consume(cancellationToken.Token);
                    Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: ${consumeResult.Message.Value}");

                    cancelled = true;

                }

                consumer.Close();
            }
        }

    }
}

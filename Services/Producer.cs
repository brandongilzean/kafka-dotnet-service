using Confluent.Kafka;
using System.Net;
using System;

namespace kafka_dotnet_service.Services
{
    public class Kafka {


        public void InitKafka()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = Dns.GetHostName(),
            };
            try
            {
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var t = producer.ProduceAsync("input-topic", new Message<Null, string> { Value = "hello world" });
                    t.ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                        }
                        else
                        {

                        Console.WriteLine($"Wrote to offset: {task.Result.Offset}");
                    }
                    });
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

    // using (var producer = new ProducerBuilder<Null, string>(config).Build())
    // {
    // }
    }
}
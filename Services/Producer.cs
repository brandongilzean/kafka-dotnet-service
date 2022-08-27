using Confluent.Kafka;
using System.Net;


var config = new ProducerConfig
{
    BootstrapServers = "host1:9092,host2:9092",
    ClientId = Dns.GetHostName(),
};


using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
}
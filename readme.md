# Simple repo for setting up .net with Kafka


## Usage
Just use the kafka-compose yaml for spinning up a kafka cluster.

```
docker-compose -f kafka-compose.yml up -d
```


### Dependencies
I've added Confluent.Kafka by doing the following:
``` 
dotnet add package Confluent.Kafka
```


### Full fledge

```
private static void SaveConverterResult(string outputFilePath, ConverterResult result)
        {
            var outputFileDirectory = Path.GetDirectoryName(outputFilePath);
            Directory.CreateDirectory(outputFileDirectory);

            var content = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Kafka kafka = new Kafka();
            kafka.InitKafka(content);

            File.WriteAllText(outputFilePath, content);
        }
```
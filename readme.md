# Simple repo for setting up .net with Kafka


## Usage
Just use the kafka-compose yaml for spinning up a kafka cluster.

```
docker-compose -f kafka-compose.yml up -d
```


### Dependencies
I've added Confluent.Kafka by doing
``` 
dotnet add package Confluent.Kafka
```
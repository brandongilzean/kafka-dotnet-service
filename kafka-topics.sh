docker-compose -f kafka-compose.yml exec broker kafka-topics --create --bootstrap-server \
localhost:9092 --replication-factor 1 --partitions 1 --topic input-topic
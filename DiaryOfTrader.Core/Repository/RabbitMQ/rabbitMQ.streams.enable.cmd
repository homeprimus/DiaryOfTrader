rem Make sure to expose stream default port 5552 and localhost via the environment (-e) option, for example:
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 -p 5552:5552 -e RABBITMQ_SERVER_ADDITIONAL_ERL_ARGS='-rabbitmq_stream advertised_host localhost' rabbitmq:3.11-managem

#затем выполнить команду
#docker exec rabbitmq rabbitmq-plugins enable rabbitmq_stream

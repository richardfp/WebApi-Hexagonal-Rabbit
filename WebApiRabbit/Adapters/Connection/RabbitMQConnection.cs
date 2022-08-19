using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebApiRabbit.Adapters.Models;


namespace WebApiRabbit.Adapters.Connection
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly ConnectionFactory _connection;
        // private readonly ILogger<RabbitMQConnection> _logger;
        public RabbitMQConnection(RabbitMQCredentials credentials)
        {
            // _logger = logger;

            _connection = new ConnectionFactory
            {
                Uri = new Uri($"amqp://{credentials.Username}:{credentials.Password}@{credentials.Host}:{credentials.Port}/")
            };
        }
        public void Publish<T>(T @object)
        {
            try
            {
                using (IConnection connection = _connection.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.BasicQos(0, 1, true);

                        channel.ExchangeDeclare("Teste-Richard", ExchangeType.Direct);

                        channel.QueueDeclare(
                            queue: "Teste-Richard",
                            durable: true,
                            exclusive: false,
                            autoDelete: false);

                        channel.QueueBind("Teste-Richard", "Teste-Richard", "directexchange_key");

                        var properties = channel.CreateBasicProperties();
                        var messageBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@object));

                        // _logger.LogInformation("Publishing message...");

                        channel.BasicPublish("Teste-Richard", "directexchange_key", properties, messageBytes);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
                // _logger.LogCritical($"ERRO: {e}");
            }

        }
    }
}

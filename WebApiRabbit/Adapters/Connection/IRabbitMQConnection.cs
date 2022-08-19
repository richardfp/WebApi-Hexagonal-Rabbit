namespace WebApiRabbit.Adapters.Connection
{
    public interface IRabbitMQConnection
    {
        void Publish<T>(T @object);
    }
}

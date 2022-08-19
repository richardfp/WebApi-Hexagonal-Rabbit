using WebApiRabbit.Adapters.Connection;

namespace WebApiRabbit.Domain.Application.UseCase.TokenEmail
{
    public class UCTokenEmail : IUCTokenEmal
    {
        private readonly IRabbitMQConnection _rabbitPubService;

        public UCTokenEmail(IRabbitMQConnection rabbitservice)
        {
            _rabbitPubService = rabbitservice;
        }
        public async Task<bool> PublishMessage<T>(T message)
        {
            _rabbitPubService.Publish<T>(message);
            return true;
        }
    }
}

using WebApiRabbit.Adapters.Connection;
using WebApiRabbit.Adapters.Models;

namespace WebApiRabbit.Adapters.Extensions
{
    public static class InjectService
    {
        public static IServiceCollection InjectServiceRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRabbitMQConnection, RabbitMQConnection>(x => new RabbitMQConnection(
                new RabbitMQCredentials
                {
                    Host = configuration.GetSection("RabbitMQ")["Host"],
                    Port = int.Parse(configuration.GetSection("RabbitMQ")["Port"]),
                    Username = configuration.GetSection("RabbitMQ")["Username"],
                    Password = configuration.GetSection("RabbitMQ")["Password"]
                }));

            return services;
        }
    }
}

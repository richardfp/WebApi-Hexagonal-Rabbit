using WebApiRabbit.Adapters.Connection;
using WebApiRabbit.Domain.Application.UseCase.TokenEmail;

namespace WebApiRabbit.Extensions
{
    public static class DomainMainExtensions
    {
        public static IServiceCollection AddDomainConfigs(this IServiceCollection services)
        {
            services.AddScoped<IUCTokenEmal, UCTokenEmail>();


            return services;
        }
    }
}

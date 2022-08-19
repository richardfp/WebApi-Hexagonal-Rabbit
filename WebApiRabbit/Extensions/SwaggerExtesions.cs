using FastEndpoints.Swagger;
namespace WebApiRabbit.Extensions

{
    public static class SwaggerExtesions
    {
        public static IServiceCollection AddSwaggerConfigs(this IServiceCollection service)
        {
            service.AddSwaggerDoc();

            return service;
        }

        public static WebApplication MapSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3(s => s.ConfigureDefaults());

            }
            return app;
        }
    }
}

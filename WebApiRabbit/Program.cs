using WebApiRabbit.Extensions;
using WebApiRabbit.Adapters.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.InjectServiceRabbitMQ(builder.Configuration);
builder.Services.AddSwaggerConfigs();
builder.Services.AddDomainConfigs();


var app = builder.Build();
app.UseFastEndpoints();
app.MapSwagger();
app.Run();

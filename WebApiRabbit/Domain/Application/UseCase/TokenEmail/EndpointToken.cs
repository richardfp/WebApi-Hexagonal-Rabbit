using FastEndpoints;
using WebApiRabbit.Adapters.Connection;
using WebApiRabbit.Domain.Core.Request;

namespace WebApiRabbit.Domain.Application.UseCase.TokenEmail
{
    public class EndpointToken : Endpoint<MyRequest, bool>
    {
            private readonly IUCTokenEmal _usecase;

            public EndpointToken(IUCTokenEmal usecase)
            {
                _usecase = usecase;
            }


            public override void Configure()
            {
                Post("produce");
                AllowAnonymous();

            }

            public override async Task HandleAsync(MyRequest req, CancellationToken ct)
            {
                var transactionRet = await _usecase.PublishMessage<ComandRequest>(new ComandRequest(req));
                await SendOkAsync(true, ct);
            }
        }
    }

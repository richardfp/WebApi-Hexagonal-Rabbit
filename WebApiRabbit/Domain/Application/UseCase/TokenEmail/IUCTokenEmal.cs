namespace WebApiRabbit.Domain.Application.UseCase.TokenEmail
{
    public interface IUCTokenEmal
    {
        Task<bool> PublishMessage<T>(T message);
    }
}

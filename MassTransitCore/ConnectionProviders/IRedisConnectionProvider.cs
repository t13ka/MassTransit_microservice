namespace MassTransitCore.ConnectionProviders
{
    public interface IRedisConnectionProvider
    {
        string Host { get; }
    }
}
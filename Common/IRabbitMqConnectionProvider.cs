namespace Abstractions
{
    public interface IRabbitMqConnectionProvider
    {
        string UriString { get; }

        string Username { get; }

        string Password { get; }
    }
}
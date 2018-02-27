namespace MassTransitCore.ConnectionProviders
{
    using Abstractions;

    public class LocalConnectionProvider : IRabbitMqConnectionProvider
    {
        public LocalConnectionProvider()
        {
            UriString = "rabbitmq://localhost";
            Username = "guest";
            Password = "guest";
        }

        public string UriString { get; }

        public string Username { get; }

        public string Password { get; }
    }
}
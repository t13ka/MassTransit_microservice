namespace MassTransitCore
{
    using Common;

    public class RabbitMqConnectionProvider : IRabbitMqConnectionProvider
    {
        public RabbitMqConnectionProvider(string uriString, string username, string password)
        {
            UriString = uriString;
            Username = username;
            Password = password;
        }

        public string UriString { get; }

        public string Username { get; }

        public string Password { get; }
    }
}
namespace Core.ConnectionProviders
{
    using System;

    public interface IRabbitMqConnectionProvider
    {
        string UriString { get; }

        string Username { get; }

        string Password { get; }

        Uri GetEndpoint(KnownServicesTypes serviceType);
    }
}
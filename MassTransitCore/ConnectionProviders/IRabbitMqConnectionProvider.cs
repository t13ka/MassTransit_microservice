namespace MassTransitCore.ConnectionProviders
{
    using System;

    using NetCoreUtils;

    public interface IRabbitMqConnectionProvider
    {
        string UriString { get; }

        string Username { get; }

        string Password { get; }

        Uri GetEndpoint(KnownServicesTypes serviceType);
    }
}
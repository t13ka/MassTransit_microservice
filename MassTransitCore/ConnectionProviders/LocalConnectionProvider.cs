namespace MassTransitCore.ConnectionProviders
{
    using System;

    using Microsoft.Extensions.Configuration;

    using NetCoreUtils;

    public class LocalConnectionProvider : IRabbitMqConnectionProvider
    {
        private readonly IConfigurationRoot _configuration;

        public LocalConnectionProvider()
        {
        }

        public LocalConnectionProvider(IConfigurationRoot configurationRoot)
        {
            _configuration = configurationRoot;
        }

        public string UriString => "rabbitmq://localhost";

        public string Username => "guest";

        public string Password => "guest";

        public Uri GetEndpoint(KnownServicesTypes serviceType)
        {
            var service = _configuration[serviceType.ToString()];

            return new Uri($"{UriString}{service}");
        }
    }
}
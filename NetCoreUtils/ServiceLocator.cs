namespace NetCoreUtils
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Configuration;

    public class ServiceLocator : IServiceLocator
    {
        private readonly IConfigurationRoot _configuration;

        public ServiceLocator()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public Uri GetEndpoint(KnownServicesTypes serviceType)
        {
            var rabbit = _configuration["RabbitMQHost"];
            var service = _configuration[serviceType.ToString()];

            return new Uri($"{rabbit}{service}");
        }
    }
}
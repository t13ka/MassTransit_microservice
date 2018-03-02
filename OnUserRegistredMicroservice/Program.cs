namespace Microservice1
{
    using System;
    using System.IO;

    using Core;
    using Core.ConnectionProviders;
    using Core.ConnectionProviders.Rabbit;
    using Core.ConnectionProviders.Redis;

    using Microsoft.Extensions.Configuration;

    class Program
    {
        public static IRabbitMqConnectionProvider ConnectionProvider;

        static void Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionProvider = new LocalConnectionProvider(configurationRoot);

            var handlersDirector = new HandlersDirector(ConnectionProvider, new HandlersProvider());

            handlersDirector.StartHandling();

            var cache = new Cache(new LocalRedisConnectionProvider());

            cache.Set("einstein", "albert");

            var test = cache.Get("einstein");
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
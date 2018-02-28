using System;

namespace OnUserRegistredMicroservice
{
    using System.IO;

    using MassTransitCore;
    using MassTransitCore.ConnectionProviders;

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

            var test = new RedisCache();
            test.Test();
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
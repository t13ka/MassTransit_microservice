namespace Microservice2
{
    using System;

    using Core;

    using Environment.ConnectionProviders.Rabbit;

    class Program
    {
        static void Main(string[] args)
        {
            var handlersDirector = new HandlersDirector(new LocalConnectionProvider(), new HandlersProvider());

            handlersDirector.StartHandling();

            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
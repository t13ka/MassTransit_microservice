using System;

namespace OnUserRegistredAndDoSomeMicroservice
{
    using System.IO;

    using MassTransitCore;
    using MassTransitCore.ConnectionProviders;

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
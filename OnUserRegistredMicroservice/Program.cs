using System;

namespace OnUserRegistredMicroservice
{
    using Common;

    using MassTransitCore;

    class Program
    {
        static void Main(string[] args)
        {
            var handlersProvider = new HandlersProvider();
            var busHandlers = handlersProvider.GetBusHandlers();
            var connectionProvider = new RabbitMqConnectionProvider("rabbitmq://localhost", "guest", "guest");
            var handlersDirector = new HandlersDirector(connectionProvider, busHandlers);

            handlersDirector.StartHandling();

            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
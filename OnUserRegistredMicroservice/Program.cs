﻿using System;

namespace OnUserRegistredMicroservice
{
    using MassTransitCore;
    using MassTransitCore.ConnectionProviders;

    class Program
    {
        static void Main(string[] args)
        {
            var handlersProvider = new HandlersProvider();
            var busHandlers = handlersProvider.GetBusHandlers();
            var handlersDirector = new HandlersDirector(new LocalConnectionProvider(), busHandlers);

            handlersDirector.StartHandling();

            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
namespace MassTransitCore
{
    using System;
    using System.Collections.Generic;

    using Abstractions;

    using MassTransit;

    public class HandlersDirector : IHandlersDirector
    {
        private readonly IEnumerable<IBusHandler> _handlers;

        private readonly IRabbitMqConnectionProvider _provider;

        public HandlersDirector(IRabbitMqConnectionProvider provider, IEnumerable<IBusHandler> handlers)
        {
            _provider = provider;
            _handlers = handlers;
        }

        public void StartHandling()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(
                sbc =>
                    {
                        var host = sbc.Host(
                            new Uri(_provider.UriString),
                            h =>
                                {
                                    h.Username(_provider.Username);
                                    h.Password(_provider.Password);
                                });

                        foreach (var busHandler in _handlers)
                        {
                            sbc.ReceiveEndpoint(host, busHandler.QueueName, e => { e.Instance(busHandler); });
                        }
                    });

            bus.Start();
        }
    }
}
namespace Core
{
    using System;

    using Abstractions;

    using Core.ConnectionProviders;

    using MassTransit;

    public class HandlersDirector : IHandlersDirector
    {
        private readonly IHandlersProvider _handlersProvider;

        private readonly IRabbitMqConnectionProvider _provider;

        public HandlersDirector(IRabbitMqConnectionProvider provider, IHandlersProvider handlersProvider)
        {
            _provider = provider;
            _handlersProvider = handlersProvider;
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

                        var handlers = _handlersProvider.GetBusHandlers();

                        foreach (var busHandler in handlers)
                        {
                            sbc.ReceiveEndpoint(host, busHandler.QueueName, e => { e.Instance(busHandler); });
                        }
                    });

            bus.Start();
        }
    }
}
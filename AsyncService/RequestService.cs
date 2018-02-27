namespace AsyncService
{
    using System;

    using MassTransit;
    using MassTransit.Pipeline.Observables;
    using MassTransit.RabbitMqTransport;
    using MassTransit.Util;

    public class RequestService
    {
        private IBusControl _busControl;

        private string _rabbitMqHost;

        private string _username;

        private string _password;

        private IRabbitMqHost _host;

        public RequestService(string rabbitMqHost, string username, string password)
        {
            _rabbitMqHost = rabbitMqHost;
            _username = username;
            _password = password;
        }

        public bool Start()
        {
            Console.WriteLine("Creating bus...");

            _busControl = Bus.Factory.CreateUsingRabbitMq(
                x =>
                    {
                        _host = x.Host(
                            new Uri(_rabbitMqHost),
                            h =>
                                {
                                    h.Username(_username);
                                    h.Password(_password);
                                });
                    });
            
            Console.WriteLine("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Stopping bus...");

            _busControl?.Stop();

            return true;
        }
    }
}
namespace Core.ConnectionProviders.Rabbit
{
    using System;

    public class ParticularConnectionProvider : IRabbitMqConnectionProvider
    {
        public ParticularConnectionProvider(string uriString, string username, string password)
        {
            UriString = uriString;
            Username = username;
            Password = password;
        }

        public string UriString { get; }

        public string Username { get; }

        public string Password { get; }

        public Uri GetEndpoint(KnownServicesTypes serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
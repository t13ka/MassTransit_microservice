namespace MassTransitCore
{
    using Abstractions;

    using MassTransitCore.ConnectionProviders;

    using StackExchange.Redis;

    public class Cache : ICache
    {
        private readonly IDatabase _db;

        public Cache(IRedisConnectionProvider connectionProvider)
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(connectionProvider.Host);
            _db = connectionMultiplexer.GetDatabase();
        }

        public void Set(string key, string value)
        {
            _db.StringSet(key, value);
        }

        public string Get(string key)
        {
            return _db.StringGet(key);
        }
    }
}
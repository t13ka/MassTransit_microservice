namespace Environment.ConnectionProviders.Redis
{
    public class LocalRedisConnectionProvider : IRedisConnectionProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalRedisConnectionProvider"/> class.
        /// </summary>
        public LocalRedisConnectionProvider()
        {
            Host = "localhost";
        }

        public string Host { get; }
    }
}
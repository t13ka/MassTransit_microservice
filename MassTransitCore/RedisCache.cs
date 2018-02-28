namespace MassTransitCore
{
    using StackExchange.Redis;

    public class RedisCache
    {
        public void Test()
        {
            // TODO: under construction
            var redis = ConnectionMultiplexer.Connect("localhost");
            //IDatabase db = redis.GetDatabase();
            //string value = "abcdefg";
            //db.StringSet("mykey", value);
            //string value2 = db.StringGet("mykey");
        }
    }
}
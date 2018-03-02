namespace Abstractions
{
    public interface ICache
    {
        void Set(string key, string value);

        string Get(string key);
    }
}
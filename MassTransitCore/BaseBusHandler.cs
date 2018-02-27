namespace MassTransitCore
{
    using Common;

    public class BaseBusHandler : IBusHandler
    {
        public string QueueName => $"{GetType().Name}_Queue";
    }
}
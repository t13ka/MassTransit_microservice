﻿namespace Core
{
    using Abstractions;

    public class BaseBusHandler : IBusHandler
    {
        public string QueueName => $"{GetType().Name}";
    }
}
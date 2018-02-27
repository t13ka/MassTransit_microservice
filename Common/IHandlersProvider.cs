namespace Common
{
    using System.Collections.Generic;

    public interface IHandlersProvider
    {
        IEnumerable<IBusHandler> GetBusHandlers();
    }
}
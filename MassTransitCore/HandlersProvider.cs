namespace MassTransitCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Abstractions;

    public class HandlersProvider : IHandlersProvider
    {
        public IEnumerable<IBusHandler> GetBusHandlers()
        {
            var currentDomain = Assembly.GetCallingAssembly();
            var type = typeof(IBusHandler);
            var types = currentDomain
                .GetTypes()
                .Where(p => type.IsAssignableFrom(p) && p.IsInterface == false);

            return types.Select(t => Activator.CreateInstance(t) as IBusHandler);
        }
    }
}
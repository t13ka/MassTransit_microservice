namespace NetCoreUtils
{
    using System;

    public interface IServiceLocator
    {
        Uri GetEndpoint(KnownServicesTypes serviceType);
    }
}
using System;

namespace AsyncService
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new RequestService("rabbitmq://localhost", "guest", "guest");
            service.Start();
            Console.ReadKey();
        }
    }
}

namespace OnUserRegistredMicroservice
{
    using System.Threading.Tasks;

    using Contracts;

    using MassTransit;

    using MassTransitCore;

    public class UserRegistredMessageHandler : BaseBusHandler, IConsumer<UserRegistredMessage>
    {
        public Task Consume(ConsumeContext<UserRegistredMessage> context)
        {
            var msg = context.Message;
            return Task.CompletedTask;
        }
    }
}
namespace OnUserRegistredAndDoSomeMicroservice
{
    using System.Threading.Tasks;

    using Abstractions.Messages.Command;

    using MassTransit;

    using MassTransitCore;

    public class SendEmailsCommandHandler : BaseBusHandler, IConsumer<ISendEmailsCommand>
    {
        public Task Consume(ConsumeContext<ISendEmailsCommand> context)
        {
            return Task.CompletedTask;
        }
    }
}
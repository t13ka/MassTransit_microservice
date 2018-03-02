namespace Microservice2
{
    using System.Threading.Tasks;

    using Abstractions.Messages.Command;

    using Core;

    using MassTransit;

    public class SendEmailsCommandHandler : BaseBusHandler, IConsumer<ISendEmailsCommand>
    {
        public Task Consume(ConsumeContext<ISendEmailsCommand> context)
        {
            return Task.CompletedTask;
        }
    }
}
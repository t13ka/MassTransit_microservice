namespace OnUserRegistredMicroservice
{
    using System;
    using System.Threading.Tasks;

    using Abstractions.Messages.Event;

    using Contracts.Commands;

    using MassTransit;

    using MassTransitCore;

    public class UserRegistredEventHandler : BaseBusHandler, IConsumer<IUserRegistredEvent>
    {
        public async Task Consume(ConsumeContext<IUserRegistredEvent> context)
        {
            var contract = new SendEmailsCommand
                               {
                                   Name = context.Message.Name,
                                   Emails = "test@test.ru; test2@test.ru"
                               };

            var sendEndpoint = await context.GetSendEndpoint(new Uri("rabbitmq://localhost/SendEmailsCommandHandler"));

            await sendEndpoint.Send(contract);
        }
    }
}
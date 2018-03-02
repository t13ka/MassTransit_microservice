namespace Microservice1
{
    using System.Threading.Tasks;

    using Abstractions.Messages.Event;

    using Contracts.Commands;

    using Core;

    using MassTransit;

    public class UserRegistredEventHandler : BaseBusHandler, IConsumer<IUserRegistredEvent>
    {
        public async Task Consume(ConsumeContext<IUserRegistredEvent> context)
        {
            var contract = new SendEmailsCommand
                               {
                                   Name = context.Message.Name,
                                   Emails = "test@test.ru; test2@test.ru"
                               };

            var endpoint = Program.ConnectionProvider.GetEndpoint(KnownServicesTypes.SendEmailsCommandHandler);

            var sendEndpoint = await context.GetSendEndpoint(endpoint);

            await sendEndpoint.Send(contract);
        }
    }
}
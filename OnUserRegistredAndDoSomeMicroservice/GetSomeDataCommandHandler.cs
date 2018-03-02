namespace Microservice2
{
    using System.Threading.Tasks;

    using Abstractions.Messages.Command;
    using Abstractions.Messages.Command.Responses;

    using Contracts.Commands.Responses;

    using Core;

    using MassTransit;

    public class GetSomeDataCommandHandler : BaseBusHandler, IConsumer<IGetSomeDataCommand>
    {
        public async Task Consume(ConsumeContext<IGetSomeDataCommand> context)
        {
            await context.RespondAsync<IGetSomeDataCommandResponse>(
                new GetSomeDataCommandResponse
                    {
                        Summaries =
                            new[]
                                {
                                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm",
                                    "Balmy", "Hot", "Sweltering", "Scorching"
                                }
                    });
        }
    }
}
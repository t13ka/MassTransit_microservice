namespace Contracts.Commands.Responses
{
    using Abstractions.Messages.Command.Responses;

    public class GetSomeDataCommandResponse : IGetSomeDataCommandResponse
    {
        public string[] Summaries { get; set; }
    }
}
namespace Abstractions.Messages.Command.Responses
{
    public interface IGetSomeDataCommandResponse
    {
        string[] Summaries { get; set; }
    }
}
namespace Contracts.Commands
{
    using Abstractions.Messages.Command;

    public class GetSomeDataCommand : IGetSomeDataCommand
    {
        public string SomeParam { get; set; }
    }
}
namespace Contracts.Commands
{
    using Abstractions.Messages.Command;

    public class SendEmailsCommand : ISendEmailsCommand
    {
        public string Name { get; set; }

        public string Emails { get; set; }
    }
}
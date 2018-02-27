namespace Abstractions.Messages.Command
{
    public interface ISendEmailsCommand
    {
        string Name { get; set; }

        string Emails { get; set; }
    }
}
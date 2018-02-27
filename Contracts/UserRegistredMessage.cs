namespace Contracts
{
    using Common;

    public class UserRegistredMessage : IBusMessage
    {
        public string Name { get; set; }
    }
}
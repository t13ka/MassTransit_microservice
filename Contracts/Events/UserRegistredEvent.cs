namespace Contracts.Events
{
    using Abstractions.Messages.Event;

    public class UserRegistredEvent : IUserRegistredEvent
    {
        public string Name { get; set; }
    }
}
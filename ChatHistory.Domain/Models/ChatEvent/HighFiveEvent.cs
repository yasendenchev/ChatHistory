using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Models.ChatEvent
{
    public class HighFiveEvent : ChatEvent
    {
        public HighFiveEvent(DateTime utcTimeStamp, User fromUser, User recipient) : base(utcTimeStamp, fromUser, EventType.HighFive)
        {
            Recipient = recipient;
        }

        public User Recipient { get; set; }
    }
}
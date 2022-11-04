using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Models.ChatEvent
{
    public abstract class ChatEvent
    {
        protected ChatEvent(DateTime utcTimeStamp, User fromUser, EventType type)
        {
            UtcTimeStamp = utcTimeStamp;
            FromUser = fromUser;
            Type = type;
        }

        public User FromUser { get; set; }

        public EventType Type { get; set; }

        public DateTime UtcTimeStamp { get; set; }
    }
}

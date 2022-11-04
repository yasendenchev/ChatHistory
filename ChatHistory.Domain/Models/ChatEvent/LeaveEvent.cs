using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Models.ChatEvent
{
    public class LeaveEvent : ChatEvent
    {
        public LeaveEvent(DateTime utcTimeStamp, User fromUser) : base(utcTimeStamp, fromUser, EventType.Leave)
        {
        }
    }
}
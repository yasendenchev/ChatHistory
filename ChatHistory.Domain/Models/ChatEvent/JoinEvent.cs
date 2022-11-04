using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Models.ChatEvent
{
    public class JoinEvent : ChatEvent
    {
        public JoinEvent(DateTime utcTimeStamp, User fromUser) : base(utcTimeStamp, fromUser, EventType.Join)
        {
        }   
    }
}
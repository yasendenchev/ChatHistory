using ChatHistory.Domain.Enums;

namespace ChatHistory.Domain.Models.ChatEvent
{
    public class CommentEvent : ChatEvent
    {
        public CommentEvent(DateTime utcTimeStamp, User fromUser, string content) : base(utcTimeStamp, fromUser, EventType.Comment)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
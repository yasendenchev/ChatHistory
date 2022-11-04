using ChatHistory.Domain.Enums;
using ChatHistory.Domain.Models;

namespace ChatHistory.Domain.Dto
{
    public sealed record ChatEventDto
    {
        public ChatEventDto(User fromUser, EventType type, DateTime utcTimeStamp, User? highFiveRecipient, string? commentContent)
        {
            FromUser = fromUser;
            Type = type;
            UtcTimeStamp = utcTimeStamp;
            HighFiveRecipient = highFiveRecipient;
            CommentContent = commentContent;
        }

        public User FromUser { get; set; }

        public EventType Type { get; set; }

        public DateTime UtcTimeStamp { get; set; }

        public User? HighFiveRecipient { get; set; }

        public string? CommentContent { get; set; }
    }
}

using ChatHistory.Domain.Models.ChatEvent;

namespace ChatHistory.Infrastructure.Data
{
    public interface IChatEventContext
    {
        IEnumerable<ChatEvent> GetChatEventsData();
    }
}
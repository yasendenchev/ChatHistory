using ChatHistory.Domain.Models.ChatEvent;

namespace ChatHistory.Infrastructure.Data
{
    public class ChatEventContext : IChatEventContext
    {
        public IEnumerable<ChatEvent> GetChatEventsData()
        {
            return InMemoryData.chatEvents;
        }
    }
}

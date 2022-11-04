using ChatHistory.Domain.DataModels;
using ChatHistory.Domain.Models.ChatEvent;

namespace ChatHistory.Infrastructure.Services.Interfaces
{
    public interface IChatEventRepository
    {
        IList<ChatEvent> GetAll(bool orderByDescending = false);

        IList<ChatEventStatisticsByHourDataModel> GetChatEventStatisticsByHour(bool orderByTimeStampDescending = false);
    }
}

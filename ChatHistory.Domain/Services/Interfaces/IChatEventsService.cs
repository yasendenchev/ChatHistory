using ChatHistory.Domain.Dto;

namespace ChatHistory.Domain.Services.Interfaces
{
    public interface IChatEventsService
    {
        IList<ChatEventDto> GetAllChatEvents(bool orderByTimeStampDescending = false);

        IList<ChatEventStatisticsByHourDto> GetChatEventStatisticsByHour(bool orderByTimeStampDescending = false);
    }
}
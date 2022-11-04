using ChatHistory.Domain.Dto;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Domain.Services.Interfaces;
using ChatHistory.Infrastructure.Services.Interfaces;

namespace ChatHistory.Infrastructure.Services
{
    public class ChatEventService : IChatEventsService
    {
        private readonly IChatEventRepository _chatEventRepository;

        public ChatEventService(IChatEventRepository chatEventRepository)
        {
            this._chatEventRepository = chatEventRepository;
        }
        public IList<ChatEventDto> GetAllChatEvents(bool orderByTimeStampDescending = false)
        {
            var events = _chatEventRepository.GetAll(orderByTimeStampDescending);

                var result = events.Select(ce => {
                    var dto = new ChatEventDto(
                        ce.FromUser,
                        ce.Type,
                        ce.UtcTimeStamp,
                        ce.Type == Domain.Enums.EventType.HighFive ? (ce as HighFiveEvent)?.Recipient : null,
                        ce.Type == Domain.Enums.EventType.Comment ? (ce as CommentEvent)?.Content : null
                        );
                    return dto;
                    })
                .ToList();

            return result;
        }

        public IList<ChatEventStatisticsByHourDto> GetChatEventStatisticsByHour(bool orderByTimeStampDescending = false)
        {
            var chatEventStatisticsData = _chatEventRepository.GetChatEventStatisticsByHour(orderByTimeStampDescending);

            var result = chatEventStatisticsData

                .Select(d => new ChatEventStatisticsByHourDto
                (
                    d.UtcTimeStamp,
                    d.JoinedCount,
                    d.LeftCount,
                    d.HighFiveInitiatorsCount,
                    d.HighFiveRecipientsCount,
                    d.CommentCount))
                .ToList();

            return result;
        }
    }
};
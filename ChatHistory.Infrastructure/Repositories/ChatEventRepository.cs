using ChatHistory.Domain.DataModels;
using ChatHistory.Domain.Dto;
using ChatHistory.Domain.Enums;
using ChatHistory.Domain.Helpers;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Infrastructure.Data;
using ChatHistory.Infrastructure.Services.Interfaces;

namespace ChatHistory.Infrastructure.Services
{
    public class ChatEventRepository : IChatEventRepository
    {
        private readonly IChatEventContext _chatEventContext;

        public ChatEventRepository(IChatEventContext chatEventContext)
        {
            _chatEventContext = chatEventContext;
        }

        public IList<ChatEvent> GetAll(bool orderByTimeStampDescending = false)
        {
            List<ChatEvent> result;
            if (orderByTimeStampDescending)
            {
                result = _chatEventContext.GetChatEventsData()
                        .OrderByDescending(c => c.UtcTimeStamp)
                        .ToList();
            }
            else
            {
                result = _chatEventContext.GetChatEventsData().ToList();
            }
            return result;
        }

        public IList<ChatEventStatisticsByHourDataModel> GetChatEventStatisticsByHour(bool orderByTimeStampDescending = false)
        {
            var chatEvents = _chatEventContext.GetChatEventsData();

            var query = chatEvents
                .GroupBy(ce => DateTimeHelper.GetDateTimeWithRoundedHour(ce.UtcTimeStamp))
                .Select(ce => new ChatEventStatisticsByHourDataModel
                (
                    utcTimeStamp: ce.Key,
                    joinedCount: ce.Count(x => x.Type == EventType.Join),
                    leftCount: ce.Count(x => x.Type == EventType.Leave),
                    commentCount: ce.Count(x => x.Type == EventType.Comment),
                    highFiveInitiatorsCount: ce.Where(hf => hf.Type == EventType.HighFive).DistinctBy(hf => hf.FromUser).Count(),
                    highFiveRecipientsCount: ce.OfType<HighFiveEvent>()
                        .Where(x => x.Type == EventType.HighFive)
                        .DistinctBy(x => x.Recipient)
                        .Count()
                ));

            if (orderByTimeStampDescending)
            {
                query.OrderByDescending(x => x.UtcTimeStamp);
            }

            var result = query.ToList();

            return result;
        }
    }
}

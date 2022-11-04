// See https://aka.ms/new-console-template for more information
using ChatHistory.Domain.Models;
using ChatHistory.Domain.Enums;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Domain.DataModels;
using ChatHistory.Domain.Helpers;
using ChatHistory.Infrastructure.Data;

namespace aa
{
    public static class A
    {
        private static User john = new User("John");
        private static User george = new User("George");
        private static User lisa = new User("Lisa");
        private static User sean = new User("Sean");
        private static User james = new User("James");
        public static List<ChatEvent> eventsData = new List<ChatEvent>
            {
                new JoinEvent(DateTime.Now.AddMinutes(-120),john),
                new JoinEvent(DateTime.Now.AddMinutes(-119),george),
                new CommentEvent(DateTime.Now.AddMinutes(-118),john, "Hello, George. High five?"),
                new HighFiveEvent(DateTime.Now.AddMinutes(-117),john, lisa),
                new HighFiveEvent(DateTime.Now.AddMinutes(-117), john, george),
                new HighFiveEvent(DateTime.Now.AddMinutes(-117), lisa, george),
                new HighFiveEvent(DateTime.Now.AddMinutes(-117), lisa, sean),
                new HighFiveEvent(DateTime.Now.AddMinutes(-117), lisa, james)
            };
    }
    public class Startup
    {
        public static void Main()
        {


            //var chatEvents = InMemoryData.chatEvents;
            //var result = chatEvents
            //    .GroupBy(ce => DateTimeHelper.GetDateTimeWithRoundedHour(ce.UtcTimeStamp))
            //    .Select(ce => new Dto{
            //        Date = DateOnly.FromDateTime
            //    {
            //        UtcTimeStamp = ce.Key,
            //        JoinedCount = ce.Count(x => x.Type == EventType.Join),
            //        LeftCount = ce.Count(x => x.Type == EventType.Leave),
            //        CommentCount = ce.Count(x => x.Type == EventType.Comment),
            //        HighFiveInitiatorsCount = ce.Where(hf => hf.Type == EventType.HighFive).DistinctBy(hf => hf.FromUser).Count(),
            //        HighFiveRecipientsCount = ce.OfType<HighFiveEvent>()
            //            .Where(x => x.Type == EventType.HighFive)
            //            .DistinctBy(x => x.Recipient)
            //            .Count(),
            //    });

            var b = 5;
        }
    }
}

public class Dto
{
    public DateOnly Date { get; set; }

    public ChatEventStatisticsByHourDataModel Data { get; set; }
}




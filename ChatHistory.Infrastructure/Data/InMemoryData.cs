using ChatHistory.Domain.Models;
using ChatHistory.Domain.Models.ChatEvent;

namespace ChatHistory.Infrastructure.Data
{
    public static class InMemoryData
    {
        private static readonly DateTime now = DateTime.UtcNow;
        private static readonly DateTime tomorrow = DateTime.UtcNow.AddDays(1);
        private static readonly DateTime yesterday = DateTime.UtcNow.AddDays(-1);
        private static User john = new User("John");
        private static User george = new User("George");
        private static User lisa = new User("Lisa");
        private static User sean = new User("Sean");
        private static User james = new User("James");
        private static User peter = new User("Peter");
        private static User david = new User("David");
        private static User rose = new User("Rose");
        public static List<ChatEvent> chatEvents = new List<ChatEvent>
            {
                new CommentEvent(yesterday, john, "Hello, George. High five?"),
                new CommentEvent(yesterday.AddMinutes(3), george, "Hi, John."),
                new CommentEvent(yesterday.AddMinutes(5), john, "How are you today?"),
                new CommentEvent(yesterday.AddMinutes(7), george, "I'm doing well, how about you?"),
                new CommentEvent(yesterday.AddMinutes(8), john, "Pretty good. I'm thinking of having some people over this Friday. Do you want to come?"),
                new CommentEvent(yesterday.AddMinutes(15), john, "Yeah, sure. I'll be there."),
                new HighFiveEvent(yesterday.AddMinutes(16), john, george),
                new CommentEvent(now, lisa, "Hey, my name is Lisa. I think we sit in the same row in Physics."),
                new CommentEvent(tomorrow.AddHours(2), sean, "Hi, Lisa. Yea, I can't catch a break with that class, seems like I never have enough time to study."),
                new CommentEvent(tomorrow.AddHours(2).AddMinutes(10), lisa, "I know what you mean. There's a lot of homework for sure."),
                new CommentEvent(tomorrow.AddHours(2).AddMinutes(20), lisa, "Exactly, plus it's tricky to juggle that with my work schedule."),
                new CommentEvent(now.AddHours(10).AddMinutes(30), peter, "Hola!"),
                new CommentEvent(now.AddHours(10).AddMinutes(31), david, "What's up, Peter"),
                new CommentEvent(now.AddHours(10).AddMinutes(31), john, "Hi"),
                new HighFiveEvent(now.AddHours(10).AddMinutes(31), james, peter),
                new CommentEvent(now.AddHours(10).AddMinutes(31), peter, "Where are we going tonight"),
                new CommentEvent(now.AddHours(10).AddMinutes(32), john, "Lets go to The Brick"),
                new CommentEvent(now.AddHours(10).AddMinutes(34), james, "I don't like it there"),
                new CommentEvent(now.AddHours(10).AddMinutes(37), peter, "Cool Cat Maya is the best bar I've been to"),
                new CommentEvent(now.AddHours(10).AddMinutes(38), john, "That's a good idea!!"),
                new CommentEvent(now.AddHours(10).AddMinutes(37), james, "Nice! I have a friend who works there"),
                new CommentEvent(now.AddHours(11).AddMinutes(5), peter, "I's Cool Cat Maya then. I'll meet you there at 8"),
                new HighFiveEvent(now.AddHours(11).AddMinutes(5), james, peter),
                new HighFiveEvent(now.AddHours(11).AddMinutes(6), john, peter),
                new HighFiveEvent(now.AddHours(11).AddMinutes(6), david, james),
                new CommentEvent(tomorrow.AddSeconds(23), lisa, "Whats the name of the last movie you saw"),
                new CommentEvent(tomorrow.AddMinutes(5), john, "I watched The Good Nurse. It was a good one"),
                new CommentEvent(tomorrow.AddMinutes(10), peter, "Virus-32.. it was a bit scary"),
                new CommentEvent(tomorrow.AddMinutes(11), lisa, "I've watched The Good Nurse as well, I liked it a lot"),
                new HighFiveEvent(tomorrow.AddMinutes(15), john, lisa),
                new JoinEvent(yesterday,john),
                new JoinEvent(yesterday.AddHours(1),george),
                new JoinEvent(now.AddDays(-120), john),
                new JoinEvent(now.AddDays(-119), george),
                new JoinEvent(now.AddDays(-120), john),
                new JoinEvent(now.AddDays(-119), george),
                new JoinEvent(now.AddDays(-120), john),
                new JoinEvent(now.AddDays(-3), peter),
                new JoinEvent(now.AddDays(-50), david),
                new JoinEvent(now, rose),
            };
    }
}
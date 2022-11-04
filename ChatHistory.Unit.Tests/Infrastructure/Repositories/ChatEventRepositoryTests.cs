using ChatHistory.Domain.Models;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Infrastructure.Data;
using ChatHistory.Infrastructure.Services;
using Moq;

namespace ChatHistory.Unit.Tests.Infrastructure.Repositories
{
    [TestClass]
    public class ChatEventRepositoryTests
    {
        private Mock<IChatEventContext> inMemoryDataProvider;

        private ChatEventRepository sut;

        [TestInitialize]
        public void Initialize()
        {
            inMemoryDataProvider = new Mock<IChatEventContext>();

            sut = new ChatEventRepository(inMemoryDataProvider.Object);
        }

        [TestMethod]
        public void GetAll_ReturnsCollectionOfChatEventsUnsorted_WhenOrderByDescendingIsFalse()
        {
            User fakeUser = new User("TestName");
            DateTime fakeDate = new DateTime(2022, 10, 22);
            List<ChatEvent> fakeChatEvents = new List<ChatEvent>
            {
                new JoinEvent(fakeDate, fakeUser),
                new LeaveEvent(fakeDate.AddMonths(1), fakeUser)
            };

            inMemoryDataProvider.Setup(x => x.GetChatEventsData()).Returns(fakeChatEvents);

            var response = sut.GetAll(false);

            Assert.AreSame(fakeChatEvents[0], response[0]);
            Assert.AreSame(fakeChatEvents[^1], response[^1]);
        }

        [TestMethod]
        public void GetAll_ReturnsCollectionOfChatEventsSortedInDescendingOrderByDate_WhenOrderByDescendingIsTrue()
        {
            User fakeUser = new User("TestName");
            User fakeRecipient = new User("TestName2");
            DateTime fakeDate = new DateTime(2022, 10, 22);
            List<ChatEvent> fakeChatEvents = new List<ChatEvent>
            {
                new CommentEvent(fakeDate, fakeUser, "my comment"),
                new HighFiveEvent(fakeDate.AddMonths(1), fakeUser, fakeRecipient)
            };

            inMemoryDataProvider.Setup(x => x.GetChatEventsData()).Returns(fakeChatEvents);

            var response = sut.GetAll(true);

            Assert.AreSame(fakeChatEvents[0], response[^1]);
        }
    }
}
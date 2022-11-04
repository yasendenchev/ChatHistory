using ChatHistory.Domain.DataModels;
using ChatHistory.Domain.Dto;
using ChatHistory.Domain.Models;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Infrastructure.Services;
using ChatHistory.Infrastructure.Services.Interfaces;
using Moq;

namespace ChatHistory.Unit.Tests.Domain.Services
{
    [TestClass]
    public class ChatEventServiceTests
    {
        private Mock<IChatEventRepository> chatEventRepository;

        private ChatEventService sut;

        [TestInitialize]
        public void Initialize()
        {
            chatEventRepository = new Mock<IChatEventRepository>();

            sut = new ChatEventService(chatEventRepository.Object);
        }

        [TestMethod]
        public void GetAllChatEvents_ReturnsCollectionOfChatEventObjects()
        {
            User fakeUser = new User("TestName");
            DateTime fakeDateTime = new DateTime(2022, 11, 22);
            string fakeCommentContent = "myComment";
            List<ChatEvent> fakeEvents = new List<ChatEvent>
            {
                new CommentEvent(fakeDateTime, fakeUser, fakeCommentContent),
            };
            List<ChatEventDto> expectedResult = new List<ChatEventDto>
            {
                new ChatEventDto(fakeUser, fakeEvents[0].Type, fakeDateTime, null, fakeCommentContent),
            };

            chatEventRepository.Setup(cr => cr.GetAll(It.IsAny<bool>())).Returns(fakeEvents);

            var response = sut.GetAllChatEvents();

            Assert.AreEqual(expectedResult[0], response[0]);
        }

        [TestMethod]
        public void GetChatEventStatisticsByHour_ReturnsCollectionOfChatEventStatisticsByHourDto()
        {
            User fakeUser = new User("TestName");
            var fakeDateTime = new DateTime(2022, 11, 22);
            List<ChatEventStatisticsByHourDataModel> fakeChatEvents = new List<ChatEventStatisticsByHourDataModel>
            {
                new ChatEventStatisticsByHourDataModel(fakeDateTime, 1, 1, 1, 1, 1)
            };
            List<ChatEventStatisticsByHourDto> expectedResult = new List<ChatEventStatisticsByHourDto>
            {
                new ChatEventStatisticsByHourDto(fakeDateTime, 1, 1, 1, 1, 1)
            };

            chatEventRepository.Setup(cr => cr.GetChatEventStatisticsByHour(It.IsAny<bool>())).Returns(fakeChatEvents);

            var response = sut.GetChatEventStatisticsByHour();

            Assert.AreEqual(expectedResult.Count, response.Count);
            Assert.AreEqual(expectedResult[0], response[0]);
        }
    }
}
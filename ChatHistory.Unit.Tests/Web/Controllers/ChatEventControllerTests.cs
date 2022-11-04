using ChatHistory.Domain.Dto;
using ChatHistory.Domain.Enums;
using ChatHistory.Domain.Models;
using ChatHistory.Domain.Models.ChatEvent;
using ChatHistory.Domain.Services.Interfaces;
using ChatHistory.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ChatHistory.Unit.Tests.Web.Controllers
{
    [TestClass]
    public class ChatEventControllerTests
    {
        private Mock<IChatEventsService> chatEventServiceMock;

        private ChatController sut;

        [TestInitialize]
        public void Initialize()
        {
            chatEventServiceMock = new Mock<IChatEventsService>();

            sut = new ChatController(chatEventServiceMock.Object);
        }

        [TestMethod]
        public void GetAllChatEvents_ReturnsCorrectResponseValue()
        {
            User fakeUser = new User("TestName");
            List<ChatEventDto> fakeChatEventsData = new List<ChatEventDto>
            {
                new ChatEventDto(fakeUser, EventType.Comment, new DateTime(2022, 11, 22), null, "my comment")
            };

            chatEventServiceMock.Setup(x => x.GetAllChatEvents(It.IsAny<bool>())).Returns(fakeChatEventsData);

            var response = (ObjectResult)sut.GetAllChatEvents();

            Assert.AreSame(fakeChatEventsData, response.Value);
        }

        [TestMethod]
        public void GetAllChatEvents_Returns200Ok()
        {
            User fakeUser = new User("TestName");
            List<ChatEventDto> fakeChatEventsData = new List<ChatEventDto>
            {
                new ChatEventDto(fakeUser, EventType.Comment, new DateTime(2022, 11, 22), null, "my comment")
            };

            chatEventServiceMock.Setup(x => x.GetAllChatEvents(default)).Returns(fakeChatEventsData);

            var response = (ObjectResult)sut.GetAllChatEvents();

            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public void GetChatEventStatisticsByHour_ReturnsCorrectData()
        {
            List<ChatEventStatisticsByHourDto> fakeChatEventStatisticsByHourData = new List<ChatEventStatisticsByHourDto>
            {
                new ChatEventStatisticsByHourDto(DateTime.Now, 1, 1, 2, 3, 4)
            };
            var fakeDateTime = DateTime.Now;

            chatEventServiceMock.Setup(x => x.GetChatEventStatisticsByHour(It.IsAny<bool>())).Returns(fakeChatEventStatisticsByHourData);

            var response = (ObjectResult)sut.GetChatEventStatisticsByHour();

            Assert.AreSame(fakeChatEventStatisticsByHourData, response.Value);
        }

        [TestMethod]
        public void GetChatEventStatisticsByHour_Returns200Ok()
        {
            List<ChatEventStatisticsByHourDto> fakeChatEventStatisticsByHourData = new List<ChatEventStatisticsByHourDto>
            {
                new ChatEventStatisticsByHourDto(DateTime.Now, 1, 1, 2, 3, 4)
            };
            var fakeDateTime = DateTime.Now;

            chatEventServiceMock.Setup(x => x.GetChatEventStatisticsByHour(It.IsAny<bool>())).Returns(fakeChatEventStatisticsByHourData);

            var response = (ObjectResult)sut.GetChatEventStatisticsByHour();

            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }
    }
}
using ChatHistory.Domain.Services.Interfaces;
using ChatHistory.Web.Controllers;
using Moq;

namespace ChatHistory.Unit.Tests.Web.Controllers
{
    public class Tests
    {
        private Mock<IChatEventService> _chatEventServiceMock;

        private ChatEventsController _chatEventsController;

        [SetUpFixture]
        public void SetUp()
        {
            _chatEventServiceMock = new Mock<IChatEventService>();

            _chatEventsController = new ChatEventsController(_chatEventServiceMock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
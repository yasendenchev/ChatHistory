using ChatHistory.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChatHistory.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatEventsService _chatEventService;

        public ChatController(IChatEventsService eventService)
        {
            _chatEventService = eventService;
        }

        [HttpGet]
        [Route("allEvents")]
        public IActionResult GetAllChatEvents()
        {
            var result = _chatEventService.GetAllChatEvents(orderByTimeStampDescending: true);

            return Ok(result);
        }

        [HttpGet]
        [Route("statistics/hour")]
        public IActionResult GetChatEventStatisticsByHour()
        {
            var result = _chatEventService.GetChatEventStatisticsByHour(orderByTimeStampDescending: true);

            return Ok(result);
        }
    }
}
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/Content")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        public readonly ILeadershipCommunicationService _leadershipCommunicationService;
        public ContentController(ILeadershipCommunicationService leadershipCommunicationService)
        {
            _leadershipCommunicationService = leadershipCommunicationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var leaderboard = await _leadershipCommunicationService.GetLeaderboardAsync();
            return Ok(leaderboard);
        }
    }
}

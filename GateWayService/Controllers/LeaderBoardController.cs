using GateWayService.DTOs.Leadership;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly ILeadershipCommunicationService _leadershipCommunicationService;
        public LeaderBoardController(ILeadershipCommunicationService leadershipCommunicationService)
        {
            _leadershipCommunicationService = leadershipCommunicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaderBoard()
        {
            var leaders = await _leadershipCommunicationService.GetAllAsync();
            return Ok(leaders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaderBoardById(int id)
        {
            var leader = await _leadershipCommunicationService.GetByIdAsync(id);
            if (leader == null) 
                return NotFound();
            return Ok(leader);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaderBoard(LeaderBoardDto boardDto)
        {
            var createleader = await _leadershipCommunicationService.CreateAsync(boardDto);
            return Ok(createleader);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaderBoard(int id, LeaderBoardDto leaderBoardDto)
        {
            var updateLeader = await _leadershipCommunicationService.UpdateAsync(id,leaderBoardDto);
            return Ok(updateLeader);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaderBoard(int id)
        {
            var leader = await _leadershipCommunicationService.DeleteAsync(id);
            if(leader)
                return Ok($"Id {id} deleted");
            return NotFound(leader);
        }
    }
}

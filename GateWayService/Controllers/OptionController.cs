using GateWayService.DTOs.Leadership;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly ILeadershipCommunicationService _leadershipCommunicationService;
        public OptionController(ILeadershipCommunicationService leadershipCommunicationService)
        {
            _leadershipCommunicationService = leadershipCommunicationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _leadershipCommunicationService.GetAllOptionsAsync();
            return Ok(options);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int optionId)
        {
            var option = await _leadershipCommunicationService.GetOptionByIdAsync(optionId);
            if (option == null) 
                return NotFound();
            return Ok(option);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOption(OptionDto optionDto)
        {
            var createOption = await _leadershipCommunicationService.CreateOptionAsync(optionDto);
            return Ok(createOption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOption(int id, OptionDto optionDto)
        {
            if(id != optionDto.OptionId)
                return NotFound($"Options with ID {id} not found");
            var updateOption = await _leadershipCommunicationService.UpdateOptionAsync(id, optionDto);  
            return Ok(updateOption);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var deleteOption = await _leadershipCommunicationService.DeleteOptionAsync(id);
            if(deleteOption)
                return Ok($"ID {id} is deleted");
            return NotFound($"Options with ID {id} not found");

        }
    }
}

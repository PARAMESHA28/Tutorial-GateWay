using GateWayService.DTOs.Tutorial;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTopicsController : ControllerBase
    {
        public readonly ITutorialCommunicationService _tutorialCommunicationService;
        public SubTopicsController(ITutorialCommunicationService tutorialCommunicationService)
        {
            _tutorialCommunicationService = tutorialCommunicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubTopicsByTopicId(int topicId)
        {
            var subTopics = await _tutorialCommunicationService.GetAllSubTopicsByTopicIdAsync(topicId);
            return Ok(subTopics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubTopicById(int id)
        {
            var subTopic = await _tutorialCommunicationService.GetSubTopicByIdAsync(id);
            return Ok(subTopic);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubTopicDto subTopic)
        {
            var createdSubTopic = await _tutorialCommunicationService.CreateSubTopicAsync(subTopic);
            return Ok(createdSubTopic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubTopicDto subTopic)
        {
            var updatedSubTopic = await _tutorialCommunicationService.UpdateSubTopicAsync(id, subTopic);
            return Ok(updatedSubTopic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tutorialCommunicationService.DeleteSubTopicAsync(id);
            if (result)
                return NoContent();
            return NotFound();
        }
    }
}

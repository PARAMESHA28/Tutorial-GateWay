using GateWayService.DTOs.Tutorial;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        public ITutorialCommunicationService _tutorialCommunicationService;
        public TopicsController(ITutorialCommunicationService tutorialCommunicationService)
        {
            _tutorialCommunicationService = tutorialCommunicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics(int courseId)
        {
            var topics = await _tutorialCommunicationService.GetAllTopicsAsync(courseId);
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var topic = await _tutorialCommunicationService.GetTopicByIdAsync(id);
            return Ok(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicDto topic)
        {
            var createdTopic = await _tutorialCommunicationService.CreateTopicAsync(topic);
            return Ok(createdTopic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TopicDto topic)
        {
            var updatedTopic = await _tutorialCommunicationService.UpdateTopicAsync(id, topic);
            return Ok(updatedTopic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tutorialCommunicationService.DeleteTopicAsync(id);
            if (result)
                return NoContent();
            return NotFound();
        }


    }
}

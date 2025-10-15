using GateWayService.DTOs.Tutorial;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
       public readonly ITutorialCommunicationService _tutorialCommunicationService;
        public ContentController(ITutorialCommunicationService tutorialCommunicationService)
        {
            _tutorialCommunicationService = tutorialCommunicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContents()
        {
            var contents = await _tutorialCommunicationService.GetAllContentsAsync();
            return Ok(contents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentById(int id)
        {
            var content = await _tutorialCommunicationService.GetContentByIdAsync(id);
            if (content == null)
                return NotFound();
            return Ok(content);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContent(ContentDto content)
        {
            var createdContent = await _tutorialCommunicationService.CreateContentAsync(content);
            return Ok(createdContent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContent(int id, ContentDto content)
        {
            var updatedContent = await _tutorialCommunicationService.UpdateContentAsync(id, content);
            return Ok(updatedContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var result = await _tutorialCommunicationService.DeleteContentAsync(id);
            if (result)
                return NoContent();
            return NotFound();
        }

    }
}

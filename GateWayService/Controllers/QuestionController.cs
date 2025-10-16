using GateWayService.DTOs.Leadership;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ILeadershipCommunicationService _leadershipCommunicationService;
        public QuestionController(ILeadershipCommunicationService leadershipCommunicationService)
        {
            _leadershipCommunicationService = leadershipCommunicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _leadershipCommunicationService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await _leadershipCommunicationService.GetQuestionByIdAsync(questionId);
            if (question == null)
                return NotFound();
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionsDto questionDto)
        {
            var createQuestion = await _leadershipCommunicationService.CreateQuestionAsync(questionDto);
            return Ok(createQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionsDto questionDto)
        {
            if (id != questionDto.QuestionId)
                return NotFound($"Question with ID {id} not found");
            var updateQuestion = await _leadershipCommunicationService.UpdateQuestionAsync(id, questionDto);
            return Ok(updateQuestion);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var deleteQuestion = await _leadershipCommunicationService.DeleteQuestionAsync(id);
            if (deleteQuestion)
                return Ok($"ID {id} is deleted");
            return NotFound($"Question with ID {id} not found");

        }
    }
}

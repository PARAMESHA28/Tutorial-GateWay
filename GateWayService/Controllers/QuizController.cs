using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
      public readonly ILeadershipCommunicationService _leadershipCommunicationService;
        public QuizController(ILeadershipCommunicationService leadershipCommunicationService)
        {
            _leadershipCommunicationService = leadershipCommunicationService;
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var quizzes = await _leadershipCommunicationService.GetAllQuizzesAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quiz = await _leadershipCommunicationService.GetQuizByIdAsync(id);
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DTOs.Leadership.QuizDto quiz)
        {
            var createdQuiz = await _leadershipCommunicationService.CreateQuizAsync(quiz);
            return Ok(createdQuiz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DTOs.Leadership.QuizDto quiz)
        {
            var updatedQuiz = await _leadershipCommunicationService.UpdateQuizAsync(id, quiz);
            return Ok(updatedQuiz);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _leadershipCommunicationService.DeleteQuizAsync(id);
            if (result)
                return NoContent();
            return NotFound();
        }


     }
}

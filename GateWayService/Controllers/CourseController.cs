//using GateWayService.Services.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace GateWayService.Controllers
//{
//    [Route("api/Course")]
//    [ApiController]
//    public class CourseController : ControllerBase
//    {
//        private readonly ITutorialCommunicationService _tutorialCommunicationService;

//        public CourseController(ITutorialCommunicationService tutorialCommunicationService)
//        {
//            _tutorialCommunicationService = tutorialCommunicationService;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllTutorials()
//        {
//            var tutorials = await _tutorialCommunicationService.GetAllAsync();
//            return Ok(tutorials);
//        }
//        [HttpPost]
//        public async Task<IActionResult> CreateCourse()
//        {
//            var courses =await _tutorialCommunicationService.Create();
//            return Ok(courses);
//        }

//    }
//}

using GateWayService.Services.Interfaces;
using GateWayService.DTOs.Tutorial;
using Microsoft.AspNetCore.Mvc;

namespace GateWayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ITutorialCommunicationService _tutorialService;

        public CourseController(ITutorialCommunicationService tutorialService)
        {
            _tutorialService = tutorialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _tutorialService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _tutorialService.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto course)
        {
            var created = await _tutorialService.CreateAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = created.CourseId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto course)
        {
            if (id != course.CourseId)
                return BadRequest();

            var updated = await _tutorialService.UpdateAsync(id, course);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tutorialService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}


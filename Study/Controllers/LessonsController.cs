using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Study.Application.Services;
using Study.Contracts.Lesson;
using Study.Domain.Models;

namespace Study.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;

        public LessonsController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
        }

        [HttpGet("getall/{courseId:guid}")]
        public async Task<IActionResult> GetAllLessons(
            [FromRoute] Guid courseId)
        {
            var lessons = await _lessonsService.GetAllLessons(courseId);

            var respones = lessons
                .Select(l => new GetLessonRespones(l.Id, l.CourseId, l.Title, l.Description));

            return Ok(respones);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var lesson = await _lessonsService.GetByIdLesson(id);
            
            if(lesson is null)
                return NotFound();

            var response = new GetLessonRespones(id, lesson.CourseId, lesson.Title, lesson.Description);

            return Ok(response);
        }

        [HttpPost("create/{courseId:guid}")]
        public async Task<IActionResult> CreateLesson(
            [FromRoute] Guid courseId,
            [FromBody] CreateLessonRequest request)
        {
            var lesson = Lesson.Create(Guid.NewGuid(), courseId, request.Title, request.Description);

            await _lessonsService.CreateLesson(lesson);

            return Ok(lesson);
        }

        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> UpdateLesson(
            [FromRoute] Guid id,
            [FromBody] UpdateLessonRequest request)
        {
            await _lessonsService.UpdateLesson(id, request.Title, request.Description);

            return NoContent();
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> DeleteLesson([FromRoute] Guid id)
        {
            await _lessonsService.DeleteLesson(id);
            return NoContent();
        }
    }
}

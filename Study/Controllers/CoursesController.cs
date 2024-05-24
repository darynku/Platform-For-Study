using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Application.Services;
using Study.Contracts.Course;
using Study.Contracts.Lesson;
using Study.Domain.Models;

namespace Study.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet("course")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _coursesService.GetAllCourse();
            return Ok(courses);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var course = await _coursesService.GetById(id);

            if (course == null) { return NotFound(); }

            return Ok(course);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
        {
            var course = Course.Create(Guid.NewGuid(), request.Title, request.Description, request.Price, request.Created);

            await _coursesService.CreateCourse(course);

            return Ok(course);
        }

        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id, 
            [FromBody] UpdateCourseRequest request)
        {
            await _coursesService.UpdateCourse(id, request.Title, request.Description, request.Price);

            return NoContent();  
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _coursesService.Delete(id);
            return NoContent();
        }

    }
}

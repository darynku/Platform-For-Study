using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Study.Contracts.Course
{
    public record UpdateCourseRequest(
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price);
}

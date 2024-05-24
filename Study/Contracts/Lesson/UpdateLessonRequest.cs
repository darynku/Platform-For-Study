using System.ComponentModel.DataAnnotations;

namespace Study.Contracts.Lesson
{
    public record UpdateLessonRequest(
        [Required, MaxLength(30, ErrorMessage = "Слишком длинное название")] string Title,
        [Required] string Description);
}

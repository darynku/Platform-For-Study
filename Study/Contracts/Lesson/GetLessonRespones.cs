namespace Study.Contracts.Lesson
{
    public record GetLessonRespones(
        Guid Id,
        Guid CourseId,
        string Title,
        string Description);
}

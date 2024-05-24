namespace Study.Contracts.Course
{
    public record GetCourseResponse(
    Guid Id,
    string Title,
    string Description,
    decimal Price,
    DateTime Created);
}

namespace Study.Contracts.Course
{
    public record CreateCourseRequest(string Title, string Description, decimal Price, DateTime Created);
}

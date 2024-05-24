namespace Study.Persistence.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public List<LessonEntity> Lessons { get; set; } = [];
    }
}

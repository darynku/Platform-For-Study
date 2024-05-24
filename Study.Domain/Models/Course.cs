namespace Study.Domain.Models
{
    public class Course
    {
        private readonly List<Lesson> _lessons = [];
        private Course(Guid id, string title, string description, decimal price, DateTime created)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Created = created;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; } = decimal.Zero;
        public DateTime Created { get; } = DateTime.UtcNow;
        public IReadOnlyList<Lesson>? Lessons => _lessons;

        public static Course Create(Guid id, string title, string description, decimal price, DateTime created)
        {
            if (string.IsNullOrEmpty(title)) throw new Exception("Null title");
            if (string.IsNullOrEmpty(description)) throw new Exception("Null description");
            
            return new Course(id, title, description, price, created);  
        }
    }
}

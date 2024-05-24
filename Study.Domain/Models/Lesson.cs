namespace Study.Domain.Models
{
    public class Lesson
    {
        private Lesson(Guid id, Guid courseId, string title, string description)
        {
            Id = id;
            CourseId = courseId;
            Title = title;
            Description = description;
        }

        public Guid Id { get;  }
        public Guid CourseId { get;  }
        public string Title { get;  } = string.Empty;
        public string Description { get;  } = string.Empty;

        public static Lesson Create(Guid id, Guid courseId, string title, string description)
        {
            if (string.IsNullOrEmpty(title)) throw new Exception("Null title");
            if (string.IsNullOrEmpty(description)) throw new Exception("Null description");

            return new Lesson(id, courseId, title, description);
        }
    }
}

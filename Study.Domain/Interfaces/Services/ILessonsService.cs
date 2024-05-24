using Study.Domain.Models;

namespace Study.Application.Services
{
    public interface ILessonsService
    {
        Task CreateLesson(Lesson lesson);
        Task DeleteLesson(Guid id);
        Task<List<Lesson>> GetAllLessons(Guid courseId);
        Task<Lesson> GetByIdLesson(Guid id);
        Task UpdateLesson(Guid id, string title, string description);
    }
}
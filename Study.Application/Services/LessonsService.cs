using Study.Domain.Models;
using Study.Persistence.Repository;

namespace Study.Application.Services
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepository _lessonsRepository;
        public LessonsService(ILessonsRepository lessonsRepository)
        {
            _lessonsRepository = lessonsRepository;
        }

        public async Task<List<Lesson>> GetAllLessons(Guid courseId)
        {
            return await _lessonsRepository.GetAll(courseId);
        }

        public async Task<Lesson> GetByIdLesson(Guid id)
        {
            return await _lessonsRepository.GetById(id);
        }

        public async Task CreateLesson(Lesson lesson)
        {
            await _lessonsRepository.Create(lesson);
        }

        public async Task UpdateLesson(Guid id, string title, string description)
        {
            await _lessonsRepository.Update(id, title, description);
        }

        public async Task DeleteLesson(Guid id)
        {
            await _lessonsRepository.Delete(id);
        }
    }
}

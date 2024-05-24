using Study.Domain.Models;
using Study.Persistence.Repository;

namespace Study.Application.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

       
        public async Task<List<Course>> GetAllCourse()
        {
            return await _coursesRepository.GetAll();
        }

        public async Task<Course> GetById(Guid id)
        {
            return await _coursesRepository.GetById(id);
        }

        public async Task CreateCourse(Course course)
        {
            await _coursesRepository.Create(course);
        }

        public async Task UpdateCourse(Guid id, string title, string description, decimal price)
        {
            await _coursesRepository.Update(id, title, description, price);
        }

        public async Task Delete(Guid id)
        {
            await _coursesRepository.Delete(id);
        }
    }
}

using Study.Domain.Models;

namespace Study.Persistence.Repository
{
    public interface ICoursesRepository
    {
        Task Create(Course course);
        Task Delete(Guid id);
        Task<List<Course>> GetAll();
        Task<Course> GetById(Guid id);
        Task Update(Guid id, string title, string description, decimal price);
    }
}
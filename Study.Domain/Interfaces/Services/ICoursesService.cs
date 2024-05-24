using Study.Domain.Models;

namespace Study.Application.Services
{
    public interface ICoursesService
    {
        Task CreateCourse(Course course);
        Task Delete(Guid id);
        Task<List<Course>> GetAllCourse();
        Task<Course> GetById(Guid id);
        Task UpdateCourse(Guid id, string title, string description, decimal price);
    }
}
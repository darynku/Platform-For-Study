using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Study.Domain.Models;
using Study.Persistence.Entities;

namespace Study.Persistence.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CoursesRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Course>> GetAll()
        {
            var courseEntity = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Lessons)
                .ToListAsync();
            return _mapper.Map<List<Course>>(courseEntity);
        }

        public async Task<Course> GetById(Guid id)
        {
            var courseEntity = await _context.Courses.
                AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("ID not found");

            return _mapper.Map<Course>(courseEntity);
        }

        public async Task Create(Course course)
        {
            var courseEntity = new CourseEntity()
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Created = course.Created,
                Price = course.Price
            };

            await _context.AddAsync(courseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, string title, string description, decimal price)
        {
            await _context.Courses.
                Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, title)
                    .SetProperty(c => c.Description, description)
                    .SetProperty(c => c.Price, price));
        }

        public async Task Delete(Guid id)
        {
            await _context.Courses.
                Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

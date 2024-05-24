using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Study.Domain.Models;
using Study.Persistence.Entities;

namespace Study.Persistence.Repository
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LessonsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Lesson>> GetAll(Guid courseId)
        {
            var lessonEntity = await _context.Lessons
                .AsNoTracking()
                .Where(l => l.CourseId == courseId)
                .ToListAsync();
            return _mapper.Map<List<Lesson>>(lessonEntity);
        }

        public async Task<Lesson> GetById(Guid id)
        {
            var lessonEntity = await _context.Lessons.
                AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<Lesson>(lessonEntity);
        }

        public async Task Create(Lesson lesson)
        {
            var lessonEntity = new LessonEntity()
            {
                Id = lesson.Id,
                CourseId = lesson.CourseId,
                Description = lesson.Description,
                Title = lesson.Title
            };
            await _context.AddAsync(lessonEntity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Guid id, string title, string description)
        {
            await _context.Lessons.
                Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, title)
                    .SetProperty(c => c.Description, description));
        }

        public async Task Delete(Guid id)
        {
            await _context.Lessons.
                Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

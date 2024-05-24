using AutoMapper;
using Study.Domain.Models;
using Study.Persistence.Entities;

namespace Study.Persistence.Mapping
{
    public class DbMapping : Profile
    {
        public DbMapping()
        {
            CreateMap<UserEntity, User>();
            CreateMap<CourseEntity, Course>();
            CreateMap<LessonEntity, Lesson>();
        }
    }
}

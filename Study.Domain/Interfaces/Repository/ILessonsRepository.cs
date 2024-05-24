﻿using Study.Domain.Models;

namespace Study.Persistence.Repository
{
    public interface ILessonsRepository
    {
        Task Create(Lesson lesson);
        Task Delete(Guid id);
        Task<List<Lesson>> GetAll(Guid courseId);
        Task<Lesson> GetById(Guid id);
        Task Update(Guid id, string title, string description);
    }
}
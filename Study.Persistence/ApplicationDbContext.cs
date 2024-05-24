using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Study.Infrastructure.Authentication;
using Study.Persistence.Entities;

namespace Study.Persistence
{

    public class ApplicationDbContext : DbContext
    {
        private readonly IPasswordHasher? _passwordHasher;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher? passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(builder =>
            {
                string password = "1234567";
                builder.HasData(new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    PasswordHash = _passwordHasher!.Generate(password),
                });
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

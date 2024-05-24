using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Study.Domain.Interfaces.Repository;
using Study.Persistence.Repository;

namespace Study.Persistence
{
    public static class PersistencExtension
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICoursesRepository, CoursesRepository>();    
            services.AddScoped<ILessonsRepository, LessonsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();    

            return services;
        }
    }
}

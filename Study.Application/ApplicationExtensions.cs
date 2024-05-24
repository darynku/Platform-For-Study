
using Microsoft.Extensions.DependencyInjection;
using Study.Application.Authentication;
using Study.Application.Services;

namespace Study.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICoursesService, CoursesService>(); 
            services.AddScoped<ILessonsService, LessonsService>(); 
            return services;
        }
    }
}

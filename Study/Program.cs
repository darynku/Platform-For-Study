using Study.Application;
using Study.Infrastructure;
using Study.Persistence;
using Study.Persistence.Mapping;


namespace Study
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            builder.Services
                .AddPersistence(builder.Configuration)
                .AddApplication()
                .AddInfrastracture(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(DbMapping));

            builder.Services.AddHttpContextAccessor();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}

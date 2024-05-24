using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Study.Persistence.Entities;

namespace Study.Persistence.Configuration
{
    public partial class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);
            builder
                .Property(c => c.Price)
                .HasPrecision(18, 2);
        }
    }
}
